using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VueCrudSolution.Data.Constants;
using VueCrudSolution.Data.Models;
using VueCrudSolution.Data.ViewModel;
using VueCrudSolution.Shared.Dto;
using VueCrudSolution.Shared.Exceptions;
using VueCrudSolution.Shared.Service.Interfaces;
using VueCrudSolution.Shared.Utils.Notification;

namespace VueCrudSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;
        private readonly IAddressService _addressSvc;
        private readonly INotifier _emailNotifier;
        private readonly AppSettings _appSettings;

        public AccountController(
            UserManager<ApplicationIdentityUser> userManager,
            RoleManager<ApplicationIdentityRole> roleManager,
            IOptions<AppSettings> appSettings,
            IAddressService addressSvc,
            INotifier emailNotifier)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressSvc = addressSvc;
            _emailNotifier = emailNotifier;
            _appSettings = appSettings.Value;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody]RegisterForDto model)
        {
            try
            {
                ApiResponse<string> response = new ApiResponse<string>();
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Email))
                    {
                        response.Code = (int)ApiResponseCodes.INVALID_REQUEST;
                        response.Description = "Email address is required.";
                        return Ok(response);
                    }
                    if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName))
                    {
                        response.Code = (int)ApiResponseCodes.INVALID_REQUEST;
                        response.Description = "FirstName & LastName is required.";
                        return Ok(response);
                    }
                    var newUser = new ApplicationIdentityUser()
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        EmailConfirmed = false,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        FullName = model.FirstName +" "+ model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        Gender = model.Gender,
                        DateOfBirth = model.DateOfBirth,
                        Activated = true,
                        CreatedOnUtc = DateTime.Now.GetDateUtcNow(),
                        LastLoginDate = DateTime.Now.GetDateUtcNow(),
                        LockoutEnabled = false
                    };
                    var password = "".GenerateRandom(9);
                    var createResult = await _userManager.CreateAsync(newUser, password);

                    if (!createResult.Succeeded)
                    {
                        response.Code = (int)ApiResponseCodes.ERROR;
                        response.Description = createResult.Errors.FirstOrDefault().Description;
                        return Ok(response);
                    }
                    createResult = await _userManager.AddToRoleAsync(newUser, "USERS");

                    if (!createResult.Succeeded)
                    {
                        await _userManager.DeleteAsync(newUser);
                        response.Code = (int)ApiResponseCodes.ERROR;
                        response.Description = createResult.Errors.FirstOrDefault().Description;
                        return Ok(response);
                    }
                    //set city and country properties
                    var userAddress = new UserAddress();
                    userAddress.IsDeleted = false;
                    userAddress.ModifiedBy_Id = newUser.Id;
                    userAddress.CreatedOn = DateTime.Now.GetDateUtcNow();
                    userAddress.ModifiedOn = DateTime.Now.GetDateUtcNow();
                    userAddress.CreatedBy_Id = newUser.Id;
                    userAddress.Region_Id = Guid.Parse(model.State);
                    userAddress.Country_Id = Guid.Parse(model.Country);
                    userAddress.City_Id = Guid.Parse(model.City);
                    userAddress.Login_Id = newUser.Id;
                    await _addressSvc.AddAsync(userAddress);
                    //generate email confirmation code
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //code = WebUtility.UrlEncode(code);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //var callbackUrl = string.Format("{0}://{1}/account/confirmemail?userId={2}&code={3}",
                    //        Request.Scheme, Request.Host.Value, 
                    //        WebUtility.HtmlEncode(newUser.Id.ToString()), code);
                    //send email
                    var message = await _emailNotifier.ReadTemplate(MessageTypes.customer_creation);
                    message = message.ParseTemplate(new Dictionary<string, string>
                        {
                            { "{first_name}", model.FirstName +" "+ model.LastName },
                            { "{email}", model.Email },
                            { "{password}", password},
                            { "{reset_link}", callbackUrl}
                        });

                    await _emailNotifier.SendAsync(model.Email, "New Account Setup", message);

                    response.Code = (int)ApiResponseCodes.OK;
                    response.Description = $"{model.Email} creation successful.";
                    return Ok(response);
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto formdata)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            var user = await _userManager.FindByEmailAsync(formdata.Email);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);
            if (user != null && await _userManager.CheckPasswordAsync(user, formdata.Password))
            {
                // Then Check If Email Is confirmed
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    response.Code = (int)ApiResponseCodes.INVALID_REQUEST;
                    response.Description = $"{formdata.Email} has not confirmed email!";
                    return BadRequest(new
                    {
                        LoginError = "We sent you an Confirmation Email. Please Confirm Your Registration With Us To Log in."
                    });
                }
                var roles = await _userManager.GetRolesAsync(user);
                var fullname = user.FirstName + " " + user.LastName;
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, formdata.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, fullname),
                        new Claim("LoggedOn", DateTime.Now.ToString())
                     }),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Site,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    expiration = token.ValidTo,
                    username = user.Email,
                    userRole = roles.FirstOrDefault()
                });
            }
            response.Code = (int)ApiResponseCodes.NOT_FOUND;
            response.Description = "Username / Password was not Found";
            return BadRequest(new
            {
                LoginError = "Please Check the Login Credentials - Invalid Username/Password was entered"
            });
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new JsonResult("ERROR");
            }

            if (user.EmailConfirmed)
            {
                return Redirect("/login");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return RedirectToAction("EmailConfirmed", "Notifications", new { userId, code }); 
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ToString());
                }
                return new JsonResult(errors);
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using VueCrudSolution.API.Web.Filters;
using VueCrudSolution.API.Web.Policies.Handlers;
using VueCrudSolution.Data.ViewModel;
using VueCrudSolution.Shared.Context;
using VueCrudSolution.Shared.DataAccess.Interface;
using VueCrudSolution.Shared.DataAccess.Interfaces;
using VueCrudSolution.Shared.DataAccess.Repository;
using VueCrudSolution.Shared.Notification.Email;
using VueCrudSolution.Shared.Service.Interfaces;
using VueCrudSolution.Shared.Service.Repository;
using VueCrudSolution.Shared.Utils.Notification;

namespace VueCrudSolution.API
{
    public partial class Startup
    {
        public static IServiceCollection AddIposbiService(IServiceCollection services)
        {
            //Register DI for Domain Service
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ApiExceptionFilter>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddTransient<INotifier, EmailNotification>();
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<AppSettings>(Startup.Configuration);
            services.AddScoped<IDbContext, MyAppContext>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            return services;
        }
    }
}

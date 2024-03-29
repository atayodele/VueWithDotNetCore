﻿using Microsoft.AspNetCore.Mvc;

namespace VueCrudSolution.API.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult EmailConfirmed(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                return Redirect("/login");
            }
            return View();
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;

namespace SUPClub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}

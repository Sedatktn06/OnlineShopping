﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

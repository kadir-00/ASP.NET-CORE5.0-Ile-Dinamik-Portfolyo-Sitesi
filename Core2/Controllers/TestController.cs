﻿using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

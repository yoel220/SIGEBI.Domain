﻿using Microsoft.AspNetCore.Mvc;

namespace SIGEBI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AcademicMarketplace.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.UserName = User.Identity.GetUserName();
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }
    }
}

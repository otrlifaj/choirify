using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Database.MySQL;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels;

namespace Trlifaj.Choirify.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.Chairman + "," + Roles.ViceChairman)]
        public IActionResult Admin()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Database.MySQL;
using Trlifaj.Choirify.ViewModels;

namespace Trlifaj.Choirify.Controllers
{
    public class HomeController : Controller
    {
        private ISongMapper SongMapper { get; set; }

        public HomeController(ISongMapper songMapper)
        {
            SongMapper = songMapper;
        }

        public IActionResult Index()
        {
            var songs = SongMapper.FindAll();
            Console.WriteLine(songs);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

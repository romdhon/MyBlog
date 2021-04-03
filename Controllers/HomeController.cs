using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ColorContext _context;

        public HomeController(ColorContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Color>> Index()
        {
            return _context.ColorItems;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

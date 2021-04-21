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
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Index(string name, int id)
        {
            ViewData["name"] = name;
            ViewData["id"] = id;
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(string iname, int iid){
            return RedirectToAction("index", new {name=iname, id=iid});
        }
    }
}
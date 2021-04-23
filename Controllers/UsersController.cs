using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blogger.Models;
using Blogger.ViewModels;

namespace Blogger.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // [HttpGet]
        public ViewResult Index()
        {
            // ViewData["name"] = name;
            // ViewData["id"] = id;
            var model = _userRepository.GetAllUser();
            return View(model);
        }

        //if want to return in json use JsonResult method and return Json(model);
        //if want to return in xml use ObjectResult method and return new ObjectResult(model) then change the service to services.AddMvc().AddXmlSerializerFormatters();
        //if want to return a view use ViewResult and return View(model) model can be the name of the view or use the absolute path(have to specify the cshtml) or relative path(../folder/view_name);
        //ViewBag and ViewData
        public ViewResult Details(int id)
        {
            User model = _userRepository.GetUser(id);
            // ViewData["user"] = model;
            UserDetailViewModel userDetailViewModel = new UserDetailViewModel()
            {
                user = model,
                PageTitle = "Detail Page"
            };
            return View(userDetailViewModel);
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        // [HttpPost]
        // public IActionResult LoginPage(string iname, int iid){
        //     return RedirectToAction("index", new {name=iname, id=iid});
        // }
    }
}
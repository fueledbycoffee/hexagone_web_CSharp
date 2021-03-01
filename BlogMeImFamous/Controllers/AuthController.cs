using BlogMeImFamous.DAL;
using BlogMeImFamous.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Controllers
{
    public class AuthController : Controller
    {
        private readonly BlogContext _context;

        public AuthController()
        {
            _context = new BlogContext();
        }

        public IActionResult Index()
        {
            return RedirectToAction("SignIn");
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserAuth auth)
        {
            User user = _context.Users
                .Where(u => u.Username == auth.Username)
                .FirstOrDefault();

            if(user != null && user.Password == auth.Password)
            {
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("Index", "Home");

            } else
            {
                ViewBag["error"] = true;
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("SignIn");
        }
    }
}

using BlogMeImFamous.DAL;
using BlogMeImFamous.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _context = new BlogContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var posts = from post in _context.Articles
                        where post.DatePublication < DateTime.Now
                        select post;

            ViewData["Posts"] = posts;

            return View();
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

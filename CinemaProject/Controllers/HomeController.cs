using DataAccess.Data;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace CinemaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaDbContext context;

        public HomeController(CinemaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.ToList();

            return View(movies);
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
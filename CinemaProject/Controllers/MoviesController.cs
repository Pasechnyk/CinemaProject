using CinemaProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    public class MoviesController : Controller
    {
        CinemaDbContext context = new CinemaDbContext();
        public IActionResult Index()
        {
            var movies = context.Movies.ToList();

            return View(movies);
        }
    }
}

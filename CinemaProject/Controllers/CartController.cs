using CinemaProject.Helpers;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    public class CartController : Controller
    {
        private readonly CinemaDbContext context;

        public CartController(CinemaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>(Constants.cartItemsKey) ?? new();

            var movies = context.Movies.Where(x => ids.Contains(x.Id)).ToList();

            return View(movies);
        }

        public IActionResult Add(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>(Constants.cartItemsKey) ?? new();

            ids.Add(id);

            HttpContext.Session.Set(Constants.cartItemsKey, ids);

            return RedirectToAction("Index", "Home");
        }
    }
}

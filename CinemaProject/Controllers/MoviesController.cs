using CinemaProject.Data;
using CinemaProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Controllers
{
    public class MoviesController : Controller
    {
        CinemaDbContext context = new CinemaDbContext();

        private void LoadGenres()
        {
            this.ViewBag.Genres = new SelectList(context.Genres.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            var movies = context.Movies.ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadGenres();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: show edit product page
        public IActionResult Edit(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) return NotFound(); // 404

            LoadGenres();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            // update product in db
            context.Movies.Update(movie);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // delete product by ID
        public IActionResult Delete(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) return NotFound(); // 404

            context.Movies.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

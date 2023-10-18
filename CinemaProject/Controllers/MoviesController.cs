using CinemaProject.Models;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly CinemaDbContext context;

        public MoviesController(CinemaDbContext context)
        {
            this.context = context;
        }

        private void LoadGenres()
        {
            this.ViewBag.Genres = new SelectList(context.Genres.ToList(), "Id", "Name");
        }

        [AllowAnonymous]
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
        [HttpPut]
        public IActionResult Edit(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) return NotFound();

            LoadGenres();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) return NotFound(); 

            context.Movies.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

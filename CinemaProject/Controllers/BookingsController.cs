using CinemaProject.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaProject.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly CinemaDbContext context;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public BookingsController(CinemaDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var items = context.Bookings.Where(x => x.UserId == CurrentUserId).ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            var ids = HttpContext.Session.Get<List<int>>(Constants.cartItemsKey) ?? new();
            var movies = context.Movies.Where(x => ids.Contains(x.Id)).ToList();

            var booking = new Booking()
            {
                Date = DateTime.Now,
                UserId = CurrentUserId,
                Movies = movies,
                TotalPrice = movies.Sum(x => x.TicketPrice)
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            // clear cart items
            HttpContext.Session.Remove(Constants.cartItemsKey);

            return RedirectToAction("Index");
        }
    }
}

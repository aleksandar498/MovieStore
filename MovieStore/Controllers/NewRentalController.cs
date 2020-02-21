using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.viewModels;

namespace MovieStore.Controllers
{
    public class NewRentalController : Controller
    {

        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
      public ActionResult Save(Rental rental)
        {
            
                var movie = _context.Movies.Single(m => m.Id == rental.MovieId);
                var customer = _context.Customers.Single(m => m.Id == rental.CustomerId);
                if (movie.NumberInStock == 0)
                {
                    return HttpNotFound("Not avalible");
                }
                movie.NumberInStock--;
                rental.Movie  = movie;
                rental.Customer = customer;
              
                   
                    rental.DateRendted = DateTime.Now;
                    
                    _context.Rentals.Add(rental);
                
               
                _context.SaveChanges();


                return RedirectToAction("Index", "NewRental");
       }







        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        [System.Web.Http.HttpPost]
        
        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var customers = _context.Customers.ToList();

            var viewModel = new NewRentalViewModel()
            {
                Movies = movies,
                Customers = customers
            };
            return View("New", viewModel);
            
        }
        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        public ActionResult Index()
        {
            
           var rental = _context.Rentals.Include(c => c.Movie).Include(c => c.Customer).ToList();
            
            return View(rental);
           

        }
        public ActionResult Details(int Id)
        {
            var rental = _context.Rentals.Include(m=>m.Customer).Include(m => m.Movie).SingleOrDefault(c => c.Id == Id);
            if (rental == null)
            {
                return HttpNotFound();
            }

            return View(rental);
        }

        public ActionResult deleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);
            if (rentalInDb == null)
                return HttpNotFound();
            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "NewRental");
        }
    }
}
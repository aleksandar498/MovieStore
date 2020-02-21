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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            if (User.IsInRole("canManageMovies"))
            {
                return View(customers);
            }
            else
            {
                return View("ReadOnly", customers);
            }
        }

        public ActionResult Details(int Id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customers==null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }
        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
          

            if (customer.Id == 0)
               _context.Customers.Add(customer);
            else
            {
                var custInDb = _context.Customers.Single(c => c.Id == customer.Id);
                custInDb.Name = customer.Name;
                custInDb.Birthday = customer.Birthday;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
                custInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

           
        }
        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypess.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("New",viewModel);
        }
        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypess.ToList()
                 
            };
            return View("New",viewModel);
        }
        [System.Web.Mvc.Authorize(Roles = "canManageMovies")]
        [System.Web.Http.HttpDelete]
        public ActionResult deleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return HttpNotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using MovieStore.Models;

namespace MovieStore.viewModels
{
    public class NewRentalViewModel
    {
        public Rental Rental { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
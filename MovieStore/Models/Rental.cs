using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class Rental
    {
        public int Id { get; set; }
        
        public Movie Movie { get; set; }
        [Required]
        [Display(Name = "Select Movie")]
        public byte MovieId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [Display(Name = "Select Customer")]
        public byte CustomerId { get; set; }
        [Display(Name = "Date Rented")]
        public DateTime DateRendted { get; set; }
        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }
    }
}
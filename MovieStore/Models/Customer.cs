using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieStore.Migrations;

namespace MovieStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Type of a membership")]
        public byte MembershipTypeId { get; set; }
        [Display(Name="Date of Birth")]
        
        public DateTime? Birthday { get; set; }
    }
}
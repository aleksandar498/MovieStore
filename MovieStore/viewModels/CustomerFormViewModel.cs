﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStore.Models;

namespace MovieStore.viewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
        
    }
}
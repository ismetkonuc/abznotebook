﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.abznotebook.Web.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);

        //Filters
        public string FilterQuery { get; set; }
    }
}

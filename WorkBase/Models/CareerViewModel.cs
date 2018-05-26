using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkBase.Models
{
    public class CareerMinimumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Desctiption { get; set; }
    }
}

    public class CareerViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Site { get; set; }
        public int RubricId { get; set; }
        public string Desctiption { get; set; }
        public string UserId { get; set; }
    }
}
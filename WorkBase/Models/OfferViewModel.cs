﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkBase.Models
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public int ResumeId { get; set; }
        public DateTime DateSend { get; set; }
        public bool Viewed { get; set; }
    }

    public class OfferDetailsViewModel
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public string CareerTitle { get; set; }
        public int ResumeId { get; set; }
        public string ResumeTitle { get; set; }
        public DateTime DateSend { get; set; }
        public bool Viewed { get; set; }
    }
}
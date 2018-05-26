using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkBase.Models
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
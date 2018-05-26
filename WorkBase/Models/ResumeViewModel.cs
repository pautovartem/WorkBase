using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkBase.Models
{
    public class ResumeMinimumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Skills { get; set; }
    }

    public class ResumeViewModel : ResumeMinimumViewModel
    {
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public int RubricId { get; set; }
        public string Portfolio { get; set; }
        public string DesiredPosition { get; set; }
        public string Payment { get; set; }
        public string UserId { get; set; }
    }
}
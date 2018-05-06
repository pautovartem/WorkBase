using System;
using System.Collections.Generic;

namespace LogicLayer.DTO
{
    public class ResumeDTO
    {
        public ResumeDTO()
        {
            Offers = new HashSet<OfferDTO>();
            ResumesExperiences = new HashSet<ResumesExperienceDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public int? City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public int RubricId { get; set; }
        public string Portfolio { get; set; }
        public string DesiredPosition { get; set; }
        public string Payment { get; set; }
        public string Skills { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<OfferDTO> Offers { get; set; }
        public virtual RubricDTO Rubric { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual ICollection<ResumesExperienceDTO> ResumesExperiences { get; set; }
    }
}

using System;

namespace LogicLayer.DTO
{
    public class ResumesExperienceDTO
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public virtual ResumeDTO Resume { get; set; }
    }
}

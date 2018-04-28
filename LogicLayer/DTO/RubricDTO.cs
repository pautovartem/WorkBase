using System.Collections.Generic;

namespace LogicLayer.DTO
{
    public class RubricDTO
    {
        public RubricDTO()
        {
            Careers = new HashSet<CareerDTO>();
            Resumes = new HashSet<ResumeDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CareerDTO> Careers { get; set; }
        public virtual ICollection<ResumeDTO> Resumes { get; set; }
    }
}

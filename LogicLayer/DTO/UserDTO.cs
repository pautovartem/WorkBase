using System.Collections.Generic;

namespace LogicLayer.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Careers = new HashSet<CareerDTO>();
            Resumes = new HashSet<ResumeDTO>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public virtual ICollection<CareerDTO> Careers { get; set; }
        public virtual ICollection<ResumeDTO> Resumes { get; set; }
    }
}

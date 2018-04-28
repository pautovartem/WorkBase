using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Careers = new HashSet<CareerDTO>();
            Resumes = new HashSet<ResumeDTO>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Nickname { get; set; }
        public byte[] Password { get; set; }
        public int UserType { get; set; }

        public virtual ICollection<CareerDTO> Careers { get; set; }
        public virtual ICollection<ResumeDTO> Resumes { get; set; }
    }
}

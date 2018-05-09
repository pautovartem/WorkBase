using Data.Identity.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Careers = new HashSet<Career>();
            Resumes = new HashSet<Resume>();
        }

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Career> Careers { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

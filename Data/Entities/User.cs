namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Careers = new HashSet<Career>();
            Resumes = new HashSet<Resume>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Skype { get; set; }

        [Required]
        [StringLength(25)]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(1024)]
        public byte[] Password { get; set; }

        public int UserType { get; set; }
        
        public virtual ICollection<Career> Careers { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}

namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Resumes")]
    public class Resume
    {
        public Resume()
        {
            Offers = new HashSet<Offer>();
            ResumesExperiences = new HashSet<ResumesExperience>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int Gender { get; set; }

        public int? City { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Skype { get; set; }

        public int RubricId { get; set; }

        [StringLength(255)]
        public string Portfolio { get; set; }

        [StringLength(255)]
        public string DesiredPosition { get; set; }

        [StringLength(10)]
        public string Payment { get; set; }

        [StringLength(255)]
        public string Skills { get; set; }

        public string UserId { get; set; }
        
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual Rubric Rubric { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ResumesExperience> ResumesExperiences { get; set; }
    }
}

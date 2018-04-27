namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resumes")]
    public partial class Resume
    {
        public Resume()
        {
            ResumesExperience = new HashSet<ResumesExperience>();
        }

        public int Id { get; set; }

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

        [StringLength(255)]
        public string Portfolio { get; set; }

        [StringLength(255)]
        public string DesiredPosition { get; set; }

        [StringLength(10)]
        public string Payment { get; set; }

        [StringLength(255)]
        public string Skills { get; set; }

        public int UserId { get; set; }

        public virtual User Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumesExperience> ResumesExperience { get; set; }
    }
}

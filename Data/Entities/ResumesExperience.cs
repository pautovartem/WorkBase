namespace Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ResumesExperiences")]
    public class ResumesExperience
    {
        [Key]
        public int Id { get; set; }

        public int ResumeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinishDate { get; set; }

        public virtual Resume Resume { get; set; }
    }
}

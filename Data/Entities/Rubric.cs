namespace Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rubrics")]
    public class Rubric
    {
        public Rubric()
        {
            Careers = new HashSet<Career>();
            Resumes = new HashSet<Resume>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public virtual ICollection<Career> Careers { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}

namespace Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Careers")]
    public class Career
    {
        public Career()
        {
            Offers = new HashSet<Offer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactName { get; set; }

        [StringLength(25)]
        public string ContactPhone { get; set; }

        [StringLength(255)]
        public string Site { get; set; }

        public int RubricId { get; set; }

        [Required]
        [StringLength(2048)]
        public string Desctiption { get; set; }

        public string UserId { get; set; }

        public virtual Rubric Rubric { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}

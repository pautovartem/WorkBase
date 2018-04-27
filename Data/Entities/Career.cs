namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Careers")]
    public partial class Career
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

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

        [Required]
        [StringLength(2048)]
        public string Desctiption { get; set; }

        public int UserId { get; set; }
    }
}

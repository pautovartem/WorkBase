namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Offers")]
    public partial class Offer
    {
        public int Id { get; set; }

        public int CareerId { get; set; }

        public int ResumeId { get; set; }
    }
}

namespace Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Offers")]
    public partial class Offer
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public int ResumeId { get; set; }
        public DateTime DateSend { get; set; }
        public bool Viewed { get; set; }

        public virtual Career Career { get; set; }
        public virtual Resume Resume { get; set; }
    }
}

using System;

namespace LogicLayer.DTO
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public int ResumeId { get; set; }
        public DateTime DateSend { get; set; }
        public bool Viewed { get; set; }

        public virtual CareerDTO Career { get; set; }
        public virtual ResumeDTO Resume { get; set; }
    }
}

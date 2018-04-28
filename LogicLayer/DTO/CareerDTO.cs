using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTO
{
    public class CareerDTO
    {
        public CareerDTO()
        {
            Offers = new HashSet<OfferDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Site { get; set; }
        public int RubricId { get; set; }
        public string Desctiption { get; set; }
        public int UserId { get; set; }

        public virtual RubricDTO Rubric { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual ICollection<OfferDTO> Offers { get; set; }
    }
}

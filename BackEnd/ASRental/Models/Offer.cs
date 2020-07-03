using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Offer
    {
        public Guid OfferId { get; set; }
        public string OfferType { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

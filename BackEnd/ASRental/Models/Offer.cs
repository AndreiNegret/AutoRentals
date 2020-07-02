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
        public string Car1 { get; set; }
        public string Car2 { get; set; }
        public string Car3 { get; set; }
        public string Car4 { get; set; }
        public string Car5 { get; set; }
    }
}

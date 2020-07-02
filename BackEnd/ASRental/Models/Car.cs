using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Car
    {
        public Guid CarId { get; set; }
        public Guid RatingId { get; set; }
        public string CarName { get; set; }
        public string CarBody { get; set; }
        public string Price { get; set; }
        public string CarPicture  { get; set; }
        public int FabricationYear { get; set; }
        public string TransmissionType { get; set; }
        public string ClimateControl { get; set; }
    }
}

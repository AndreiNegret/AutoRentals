using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Driver
    {
        public Guid DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverType { get; set; }
        public string ProfilePicture { get; set; }
        public int PhoneNumber { get; set; }
    }
}

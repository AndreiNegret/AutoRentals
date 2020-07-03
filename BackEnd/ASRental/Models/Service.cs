using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string ServiceType { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

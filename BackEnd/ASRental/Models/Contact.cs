using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CarNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

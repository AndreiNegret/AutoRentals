using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public Guid BookCarId { get; set; }
        public Guid OfferId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

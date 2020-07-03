using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Rating
    {
        public Guid RatingId { get; set; }
        public int Value { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}

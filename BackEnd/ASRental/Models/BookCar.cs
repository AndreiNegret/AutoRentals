using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class BookCar
    {
        public Guid BookCarId { get; set; }
        public Guid CarId { get; set; }
        public string Location { get; set; }
        public DateTime PickDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarName { get; set; }

    }
}

using ASRental.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class BookCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookCarId { get; set; }
        public string Location { get; set; }
        public DateTime PickDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarName { get; set; }

        public BookCar()
        {
        }

        public BookCar(BookCar bookCar)
        {
            Location = bookCar.Location;
            PickDate = bookCar.PickDate;
            ReturnDate = bookCar.ReturnDate;
            CarName = bookCar.CarName;
        }

        public BookCar(BookCarDto bookCarDto)
        {
            Location = bookCarDto.Location;
            PickDate = bookCarDto.PickDate;
            ReturnDate = bookCarDto.ReturnDate;
            CarName = bookCarDto.CarName;
        }
    }
}

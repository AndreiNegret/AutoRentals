using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ASRental.Dto
{
    [DataContract]
    public class BookCarDto
    {
        [DataMember(Name = "location")]
        [Required]
        public string Location { get; set; }

        [DataMember(Name = "pickDate")]
        [Required]
        public DateTime PickDate { get; set; }

        [DataMember(Name = "returnDate")]
        [Required]
        public DateTime ReturnDate { get; set; }

        [DataMember(Name = "carName")]
        [Required]
        public string CarName { get; set; }
    }
}
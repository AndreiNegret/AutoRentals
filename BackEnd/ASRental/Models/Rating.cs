﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Value { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
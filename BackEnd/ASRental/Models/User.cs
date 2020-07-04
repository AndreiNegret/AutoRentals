using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    [NotMapped]
    public class User : ApplicationUser
    {

        [DisplayName("UserName")]
        public string Username { get; set; }
   
    }
}

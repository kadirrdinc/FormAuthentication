using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

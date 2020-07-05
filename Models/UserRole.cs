using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class UserRole:BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Role { get; set; }
    }
}

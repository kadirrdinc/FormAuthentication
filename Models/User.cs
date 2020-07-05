using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Doğru formatta email giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int UserRoleID { get; set; }
        public UserRole UserRole { get; set; }
        
        public bool isConfirmed { get; set; }
        public Guid ActivationCode { get; set; }

        public IEnumerable<UserMenu> UserMenus { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class Menu:BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UrlLink { get; set; }

        public IEnumerable<UserMenu> UserMenus { get; set; }

    }
}

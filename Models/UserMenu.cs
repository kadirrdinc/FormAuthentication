using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class UserMenu
    {
        public int ID { get; set; }
        
        public int UserID { get; set; }
        public User User { get; set; }

        public int MenuID { get; set; }
        public Menu Menu { get; set; }
    }
}

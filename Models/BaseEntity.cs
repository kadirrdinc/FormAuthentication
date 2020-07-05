using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormAuthentication.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}

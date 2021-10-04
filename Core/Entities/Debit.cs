using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Debit
    {
        public Guid DebitID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsApproved { get; set; }
        public Guid UserID { get; set; }
        //nav prop
        public User User { get; set; }
    }
}

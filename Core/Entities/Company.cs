using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public byte Logo { get; set; }
        public int PlanID { get; set; }
        public virtual Comment Comment { get; set; }
        ICollection<User> Users { get; set; }

    }
}

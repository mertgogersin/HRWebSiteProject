using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Plan
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public double Price { get; set; }
        //nav prop
        public ICollection<Company> Companies { get; set; }
    }
}

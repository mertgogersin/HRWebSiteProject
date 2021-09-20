using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Bonus
    {
        public int UserID { get; set; }
        public decimal BonusAmount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public User User { get; set; }

    }
}

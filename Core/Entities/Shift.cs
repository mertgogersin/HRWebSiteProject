using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime BreakTime { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}

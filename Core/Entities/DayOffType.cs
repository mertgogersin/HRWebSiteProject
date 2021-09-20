using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DayOffType
    {
        public int DayOffTypeID { get; set; }
        public string TypeName { get; set; }
        public ICollection<DayOff> DayOffs { get; set; }

    }
}

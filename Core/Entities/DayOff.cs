using Core.Entities.BaseEntities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DayOff :WorkState
    {
        public Guid DayOffID { get; set; }
        public Guid DayOffTypeID { get; set; }
        public bool IsApproved { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        //nav prop
        public DayOffType DayOffType { get; set; }

    }
}

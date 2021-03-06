using Core.Entities.BaseEntities;
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
        public Guid ShiftID { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BreakTime { get; set; }
        //nav prop
        public ICollection<UserShift> UserShifts { get; set; }
    }
}

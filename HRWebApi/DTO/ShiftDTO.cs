using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class ShiftDTO
    {
        public Guid ShiftID { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? BreakTime { get; set; }
    }
}

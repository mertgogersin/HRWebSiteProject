using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class DayOffDTO
    {
        public Guid DayOffID { get; set; }
        public string Title { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public Guid DayOffTypeID { get; set; }
    }
}

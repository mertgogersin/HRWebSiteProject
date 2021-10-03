using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class ShiftDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BeginDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class CompanySaveDTO
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public byte[] Logo { get; set; }
        public bool IsApprove { get; set; }
    }
}

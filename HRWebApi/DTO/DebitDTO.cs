using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class DebitDTO
    {
        public Guid DebitID { get; set; }
        public Guid UserID { get; set; }
        public bool? IsApproved { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

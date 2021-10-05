using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class AddNotificationDTO
    {
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid UserID { get; set; }
    }
}

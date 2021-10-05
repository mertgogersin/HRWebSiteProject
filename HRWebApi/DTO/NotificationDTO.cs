using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class NotificationDTO
    {
        public Guid NotificationID { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid UserID { get; set; }

    }
}

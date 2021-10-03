using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Notification
    {
        public Guid NotificationID { get; set; }
        public string NotificationFromName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsSeen { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public Guid UserID { get; set; }
        //nav prop
        public User User { get; set; }
    }
}

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
        public int NotificationID { get; set; }
        public string NotificationFromName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? IsSeen { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
    }
}

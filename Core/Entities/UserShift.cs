using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserShift
    {
        public Guid UserID { get; set; }
        public Guid ShiftID { get; set; }
        //nav
        public User User { get; set; }
        public Shift Shift { get; set; }


    }
}

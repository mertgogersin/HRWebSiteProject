using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Authentication
{
    public class User : IdentityUser<Guid>
    {
        //scalar property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public double Salary { get; set; }
        public bool IsApprove { get; set; }
        public Guid CompanyID { get; set; }
        
        //navigational properties
        public Company Company { get; set; }
        public ICollection<UserShift> UserShifts { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Debit> Debits { get; set; }
        public ICollection<DayOff> DayOffs { get; set; }
        public ICollection<Bonus> Bonuses { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}

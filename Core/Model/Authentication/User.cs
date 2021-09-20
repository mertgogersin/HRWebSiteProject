using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Authentication
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }


        public DateTime StartingDate { get; set; }
        public byte Photo { get; set; }
        public double Salary { get; set; }
        public int CompanyID { get; set; }
        public int VacationID { get; set; }
        public Vacation Vacation { get; set; }
        public ICollection<Shift> Shifts { get; set; }
        public int ExpenseID { get; set; }
        public ICollection<Debit> Debits { get; set; }
    }
}

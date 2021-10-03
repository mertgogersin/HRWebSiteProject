using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class ExpenseDTO
    {
        public Guid ExpenseID { get; set; }
        public Guid Id { get; set; } //userID
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
    }
}

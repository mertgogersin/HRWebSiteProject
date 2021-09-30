using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid CompanyID { get; set; }
        public bool IsActive { get; set; }
    }
}

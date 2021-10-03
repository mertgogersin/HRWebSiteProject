using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class RecruitmentDTO
    {
        //Employer'ın employee ekleme sayfası için
        public Guid Id { get; set; }
        public Guid CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartingDate { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
    }
}

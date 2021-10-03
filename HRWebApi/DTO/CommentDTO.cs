using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class CommentDTO
    {
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public Guid CompanyID { get; set; }//Yorum detay için şirket bilgileri
    }
}

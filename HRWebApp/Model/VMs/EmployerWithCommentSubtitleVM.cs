using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApp.Model.VMs
{
    public class EmployerWithCommentSubtitleVM
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string CommentSubtitle { get; set; }
        public byte[] Photo { get; set; }
    }
}

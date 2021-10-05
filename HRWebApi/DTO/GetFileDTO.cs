using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class GetFileDTO
    {
        public Guid FileID { get; set; }
        public string FileName { get; set; }
        public byte[] Files { get; set; }
        public Guid FileTypeID { get; set; }
        public Guid UserID { get; set; }
    }
}

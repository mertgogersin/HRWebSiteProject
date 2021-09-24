using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class File
    {
        public Guid FileID { get; set; }
        public string FileName { get; set; }
        public byte[] Files { get; set; }
        public Guid FileTypeID { get; set; }
        public Guid UserID { get; set; }
        //nav prop
        public FileType FileType { get; set; }
        public User User { get; set; }
    }
}

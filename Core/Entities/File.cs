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
        public int FileID { get; set; }
        public string FileName { get; set; }
        public int FileTypeID { get; set; }
        public FileType FileType { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
    }
}

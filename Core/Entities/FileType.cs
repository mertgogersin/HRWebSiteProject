using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FileType
    {
        public int FileTypeID { get; set; }
        public string FileTypeName { get; set; }
        //nav prop
        public ICollection<File> Files { get; set; }
    }
}

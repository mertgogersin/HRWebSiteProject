using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.DTO
{
    public class SaveFileDTO
    {
        public string FileName { get; set; }
        public byte[] Files { get; set; }
    }
}

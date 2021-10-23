using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comment
    {
        public Guid CommentID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public Guid? CompanyID { get; set; }
        //nav prop
        public Company Company { get; set; }
        //asdasdasdasdsad
    }
}

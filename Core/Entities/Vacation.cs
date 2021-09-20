using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Vacation
    {
        public int VacationID { get; set; }
        public string Title { get; set; }
        public DateTime Duration { get; set; }
        public ICollection<User> Users { get; set; }

    }
}

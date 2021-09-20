using Core.Entities.BaseEntities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Vacation :WorkState
    {
        public int VacationID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

    }
}

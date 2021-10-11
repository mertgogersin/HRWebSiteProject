using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Bonus
    {
        public Guid BonusID { get; set; }
        public Guid UserID { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal BonusAmount { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        //nav prop
        public User User { get; set; }

    }
}

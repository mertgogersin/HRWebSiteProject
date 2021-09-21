﻿using Core.Entities.BaseEntities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Shift : WorkState
    {
        public int ShiftID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BreakTime { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

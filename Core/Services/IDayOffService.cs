﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDayOffService
    {
        Task<IEnumerable<DayOff>> WaitingApprovementDayOffsAsync(Guid companyID);
        Task<DayOffType> CreateDayOffTypeAsync(DayOffType newDayOffType);
    }
}

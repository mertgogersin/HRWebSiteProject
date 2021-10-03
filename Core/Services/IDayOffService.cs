using Core.Entities;
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
        Task<IEnumerable<DayOff>> GetAllDayOffsByUserIDAsync(Guid userID);
        Task<string> AddDayOffAsync(DayOff dayOff);
        Task<string> UpdateDayOffAsync(DayOff dayOff);
        Task DeleteDayOffAsync(Guid dayOffID);
    }
}

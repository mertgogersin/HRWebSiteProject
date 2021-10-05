using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAllActiveShiftsByUserIDAsync(Guid userID);
        Task<IEnumerable<Shift>> GetAllShiftsByUserIDAsync(Guid userID);
        Task<IEnumerable<Shift>> GetShiftsAsync();
        Task<Shift> GetShiftByIDAsync(Guid shiftID);
        Task<string> AddShiftAsync(Shift shift);
        Task<string> UpdateShiftAsync(Shift shift);
        Task DeleteShiftAsync(Guid shiftID);
    }
}

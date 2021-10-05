using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork unitOfWork;
        public ShiftService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddShiftAsync(Shift shift)
        {
            string error = null;
            try
            {
                await unitOfWork.Shifts.AddAsync(shift);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Shift couldn't be added!";
            }
            return error;
        }

        public async Task DeleteShiftAsync(Guid shiftID)
        {
            Shift shiftToDelete = await unitOfWork.Shifts.GetByIdAsync(shiftID);
            shiftToDelete.IsActive = false;
            unitOfWork.Shifts.Delete(shiftToDelete);
        }

        public async Task<IEnumerable<Shift>> GetAllActiveShiftsByUserIDAsync(Guid userID)
        {
            List<Shift> shifts = (List<Shift>)await GetAllShiftsByUserIDAsync(userID);
            return shifts.Where(m => m.IsActive);
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsByUserIDAsync(Guid userID)
        {
            return await unitOfWork.Shifts.GetShiftsByUserIDAsync(userID);
        }

        public async Task<Shift> GetShiftByIDAsync(Guid shiftID)
        {
            return await unitOfWork.Shifts.GetByIdAsync(shiftID);
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            return await unitOfWork.Shifts.GetAllAsync();
        }

        public async Task<string> UpdateShiftAsync(Shift shift)
        {
            string error = null;
            try
            {
                unitOfWork.Shifts.Update(shift);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Shift couldn't be updated!";
            }
            return error;
        }
    }
}

using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DayoffService : IDayOffService
    {
        private readonly IUnitOfWork unitOfWork;
        public DayoffService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DayOff>> WaitingApprovementDayOffsAsync(Guid companyID)
        {
            List<DayOff> dayOffs = new List<DayOff>();
            foreach (User item in (List<User>)unitOfWork.Users.List(x => x.CompanyID == companyID))
            { dayOffs.AddRange(item.DayOffs.Where(x => x.IsApproved == null)); }

            return await Task.FromResult(dayOffs);
        }
        public async Task<DayOffType> CreateDayOffTypeAsync(DayOffType newDayOffType)
        {
            await unitOfWork.OffDays.CreateDayOffTypeAsync(newDayOffType);
            await unitOfWork.CommitAsync();

            return newDayOffType;
        }

        public async Task<IEnumerable<DayOff>> GetAllDayOffsByUserIDAsync(Guid userID)
        {
            return await unitOfWork.OffDays.GetOffDaysByUserIDAsync(userID);
        }

        public async Task<string> AddDayOffAsync(DayOff dayOff)
        {
            string error = null;
            try
            {
                await unitOfWork.OffDays.AddAsync(dayOff);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Off day couldn't be added!";
            }
            return error;
        }

        public async Task<string> UpdateDayOffAsync(DayOff dayOff)
        {
            string error = null;
            try
            {
                unitOfWork.OffDays.Update(dayOff);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Off day couldn't be updated!";
            }
            return error;
        }

        public async Task DeleteDayOffAsync(Guid dayOffID)
        {
            DayOff dayOffToDelete = await unitOfWork.OffDays.GetByIdAsync(dayOffID);
            dayOffToDelete.IsActive = false;
            unitOfWork.OffDays.Delete(dayOffToDelete);
        }
    }
}

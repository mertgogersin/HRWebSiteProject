using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IOffDayRepository :IRepository<DayOff>
    {
        Task CreateDayOffTypeAsync(DayOffType dayOffType);
        Task<IEnumerable<DayOff>> GetOffDaysByUserIDAsync(Guid userID);


        //Task SetDayOffType(DayOffType dayOff); //revize yapılacak
    }
}

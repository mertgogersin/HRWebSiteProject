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
        //Task SetDayOffType(DayOffType dayOff); //revize yapılacak
    }
}

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
        Task<IEnumerable<DayOff>> GetDummyClassDayOffsByUserID(string userID);
        //Task SetDayOffType(DayOffType dayOff); //revize yapılacak
    }
}

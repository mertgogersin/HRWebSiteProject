using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OffDayRepository : Repository<DayOff>, IOffDayRepository
    {
        public OffDayRepository(HRContext context):base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task CreateDayOffTypeAsync(DayOffType dayOffType)
        {
            await context.AddAsync(dayOffType);
        }

        public async Task<IEnumerable<DayOff>> GetOffDaysByUserIDAsync(Guid userID)
        {
            List<Guid> offDaysID = await Context.DayOffs.Where(x => x.UserID == userID).Select(x => x.DayOffID).ToListAsync();
            List<DayOff> dayOffs = new List<DayOff>();
            foreach (Guid item in offDaysID)
            {
                dayOffs.Add(Context.DayOffs.Where(x => x.DayOffID == item).FirstOrDefault());
            }
            return dayOffs;        
        }
    }
}

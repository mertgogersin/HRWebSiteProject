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
    }
}

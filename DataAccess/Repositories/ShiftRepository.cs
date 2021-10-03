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
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        public ShiftRepository(HRContext context) : base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<Shift>> GetShiftsByUserIDAsync(Guid userID)
        {
            List<Guid> shiftIDs = await Context.UserShifts.Where(m => m.UserID == userID).Select(m => m.ShiftID).ToListAsync();
            List<Shift> shifts = new List<Shift>();
            foreach (Guid item in shiftIDs)
            {
                shifts.Add(Context.Shifts.Where(m => m.ShiftID == item).FirstOrDefault());
            }
            return shifts;
        }
    }
}

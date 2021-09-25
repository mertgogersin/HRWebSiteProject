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
    public class BonusRepository : Repository<Bonus>, IBonusRepository
    {
        public BonusRepository(HRContext context): base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<Bonus>> GetBonusesByUserIDAsync(Guid userID)
        {
            return await Context.Bonuses.Where(m => m.UserID == userID).ToListAsync();
        }
    }
}

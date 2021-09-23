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
   public class DebitRepository : Repository<Debit>,IDebitRepository
    {
        public DebitRepository(HRContext context):base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<Debit>> GetDebitsByUserID(Guid userID)
        {
            return await Context.Debits.Where(m => m.UserID == userID).ToListAsync();
        }
    }
}

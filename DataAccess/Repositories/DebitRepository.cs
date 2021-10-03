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
        public async Task<Debit> GetDebitByIDAsync(Guid debitID)
        {
            return await Context.Debits.Where(x => x.DebitID == debitID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Debit>> GetDebitsByUserIDAsync(Guid userID)
        {
            List<Guid> debitIDs = await Context.Debits.Where(x => x.UserID == userID).Select(x => x.DebitID).ToListAsync();
            List<Debit> debits = new List<Debit>();
            foreach (Guid item in debitIDs)
            {
                debits.Add(Context.Debits.Where(x => x.DebitID == item).FirstOrDefault());
            }
            return debits;
            
        }
    }
}

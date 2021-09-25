using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBonusRepository : IRepository<Bonus>
    {
        Task<IEnumerable<Bonus>> GetBonusesByUserIDAsync(Guid userID);
    }
}

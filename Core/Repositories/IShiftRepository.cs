using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IShiftRepository:IRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetShiftsByUserID(Guid userID);
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IFileRepository : IRepository<File>
    {
        Task<IEnumerable<File>> GetFilesByUserIDAsync(Guid userID);
    }
}

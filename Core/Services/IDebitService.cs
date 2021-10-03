using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDebitService
    {
        Task<IEnumerable<Debit>> GetAllDebitsByUserIDAsync(Guid userID);
        Task<IEnumerable<Debit>> GetAllApproveDebitsByUserIDAsync(Guid userID);
        Task<string> AddDebitAsync(Debit debit);
        Task<string> UpdateDebitAsync(Debit debit);
        Task DeleteDebitAsync(Guid debitID);

    }
}

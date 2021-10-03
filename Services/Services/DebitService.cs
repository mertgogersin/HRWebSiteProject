using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DebitService : IDebitService
    {
        private readonly IUnitOfWork unitOfWork;
        public DebitService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<string> AddDebitAsync(Debit debit)
        {
            string error = null;
            try
            {
                await unitOfWork.Debits.AddAsync(debit);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Debit couldn't be added!";
            }
            return error;
        }

        public async Task DeleteDebitAsync(Guid debitID)
        {
            Debit debitToDelete = await unitOfWork.Debits.GetByIdAsync(debitID);
            debitToDelete.IsApproved = false;
            unitOfWork.Debits.Delete(debitToDelete);
        }

        public async Task<IEnumerable<Debit>> GetAllApproveDebitsByUserIDAsync(Guid userID)
        {
            List<Debit> debits = (List<Debit>)await GetAllDebitsByUserIDAsync(userID);
            return debits.Where(x => x.IsApproved);
        }

        public async Task<IEnumerable<Debit>> GetAllDebitsByUserIDAsync(Guid userID)
        {
            return await unitOfWork.Debits.GetDebitsByUserIDAsync(userID);
        }

        public async Task<string> UpdateDebitAsync(Debit debit)
        {
            string error = null;
            try
            {
                unitOfWork.Debits.Update(debit);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Debit couldn't be updated!";
            }
            return error;
        }
    }
}

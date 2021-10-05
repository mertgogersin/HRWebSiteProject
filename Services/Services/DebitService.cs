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
        public async Task<Debit> GetDebitByIDAsync(Guid debitID)
        {
            return await unitOfWork.Debits.GetByIdAsync(debitID);
        }
        public async Task DeleteDebitAsync(Guid debitID)
        {
            Debit debitToDelete =await GetDebitByIDAsync(debitID);
            debitToDelete.IsApproved = false;
            unitOfWork.Debits.Delete(debitToDelete);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Debit>> GetAllApproveDebitsByUserIDAsync(Guid userID)
        {
            List<Debit> debits = (List<Debit>)await GetAllDebitsByUserIDAsync(userID);
            return debits.Where(x => x.IsApproved == true);
        }

        public async Task<IEnumerable<Debit>> GetAllDebitsByUserIDAsync(Guid userID)
        {
            List<Debit> debits = (List<Debit>)await unitOfWork.Debits.GetDebitsByUserIDAsync(userID);
            return debits.Where(m => m.IsApproved != null);
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

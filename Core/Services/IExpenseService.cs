using Core.Entities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IExpenseService
    {
        Task<Expense> GetByExpenseIDAsync(Guid expenseID);
        Task<IEnumerable<Expense>> WaitingApproveExpenseAsync(Guid userID);
        Task<string> AddExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<IEnumerable<Expense>> GetExpensesByUserIDAsync(Guid userID);
    }
}

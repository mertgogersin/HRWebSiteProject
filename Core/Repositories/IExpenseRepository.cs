using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesByUserIDAsync(Guid userID);
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense> GetExpenseByIDAsync(Guid expenseID);
        Task AddExpenseAsync(Expense expense);

    }
}

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
        Task<IEnumerable<Expense>> GetExpensesByUserID(Guid userID);
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpenseByID(Guid expenseID);
        Task AddExpense(Expense expense);

    }
}

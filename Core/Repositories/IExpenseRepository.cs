using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<IEnumerable<Expense>> List(Expression<Func<Expense, bool>> predicate);

    }
}

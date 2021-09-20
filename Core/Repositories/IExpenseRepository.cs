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
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> AddExpense(Expense expense);

    }
}

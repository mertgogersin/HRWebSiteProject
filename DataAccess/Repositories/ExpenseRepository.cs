using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        HRContext context;
        public ExpenseRepository(HRContext context)
        {
            this.context = context;
        }
        public async Task AddExpense(Expense expense)
        {
            await context.Expenses.AddAsync(expense);          
        }

        public async Task<Expense> GetExpenseByID(Guid expenseID)
        {
            return await context.Expenses.Where(m => m.ExpenseID == expenseID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            return await context.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserID(Guid userID)
        {
            return await context.Expenses.Where(m => m.UserID == userID).ToListAsync();
        }
    }
}

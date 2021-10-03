using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private HRContext context;
        public ExpenseRepository(HRContext context)
        {
            this.context = context;
        }
        
        public async Task AddExpenseAsync(Expense expense)
        {
            await context.Expenses.AddAsync(expense);          
        }
        
        public async Task<Expense> GetExpenseByIDAsync(Guid expenseID)
        {
            return await context.Expenses.Where(m => m.ExpenseID == expenseID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await context.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserIDAsync(Guid userID)
        {
            return await context.Expenses.Where(m => m.UserID == userID).ToListAsync();
        }
        public async Task<IEnumerable<Expense>> List(Expression<Func<Expense, bool>> predicate)
        {
            return await Task.FromResult(context.Expenses.Where(predicate));
        }
    }
}

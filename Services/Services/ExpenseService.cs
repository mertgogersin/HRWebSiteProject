using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;
        public ExpenseService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<Expense>> WaitingApproveExpenseAsync(Guid userID)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (User item in (List<User>)unitOfWork.Users.List(x => x.Id == userID))
            {
                expenses.AddRange(item.Expenses.Where(x => x.IsApproved == null));
            }

            return await Task.FromResult(expenses);
        }

        public async Task<Expense> GetByExpenseIDAsync(Guid expenseID)
        {
            Expense expense = await unitOfWork.Expenses.GetExpenseByIDAsync(expenseID);

            return expense;
        }

        public async Task<string> AddExpenseAsync(Expense expense)
        {
            string error = null;
            try
            {
                await unitOfWork.Expenses.AddExpenseAsync(expense);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Expense couldn't be added!";
            }
            return error;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await unitOfWork.Expenses.GetExpensesAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserIDAsync(Guid userID)
        {
            return await unitOfWork.Expenses.GetExpensesByUserIDAsync(userID);
        }
    }
}

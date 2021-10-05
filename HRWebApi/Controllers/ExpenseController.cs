using AutoMapper;
using Core.Entities;
using Core.Services;
using HRWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService expenseService;
        private readonly IMapper mapper;

        public ExpenseController(IExpenseService _expenseService, IMapper _mapper)
        {
            this.expenseService = _expenseService;
            this.mapper = _mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesByUserIDAsync(Guid id)
        {
            List<Expense> expenses = (List<Expense>)await expenseService.GetExpensesByUserIDAsync(id);
            List<ExpenseDTO> expenseDTOs = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenses);
            return Ok(expenseDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseDTO expenseDTO)
        {
            if (ModelState.IsValid)
            {
                Expense expense = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
                string error = await expenseService.AddExpenseAsync(expense);
                if (error != null)
                    return BadRequest(error);
                return Ok("Expense successfully added.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseByID(Guid id)
        {
            Expense expense = await expenseService.GetByExpenseIDAsync(id);
            return Ok(expense);
        }
       
    }
}

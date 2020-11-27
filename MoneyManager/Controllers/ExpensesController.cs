using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO.Money;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesDAL _expensesDAL;
        private readonly ExpensesDTO _expensesDTO;

        public ExpensesController(IExpensesDAL expensesDAL, ExpensesDTO expensesDTO)
        {
            _expensesDAL = expensesDAL;
            _expensesDTO = expensesDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpense(int id)
        {
            var expense = await _expensesDAL.Get(id);

            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpensesDTO model)
        {
            var expense = new ExpensesDTO()
            {
                Amount = model.Amount,
                Id = model.Id,
                OutcomeDate = model.OutcomeDate,
                Title = model.Title,
                Type = model.Type,
                UserId = model.UserId
            };

            await _expensesDAL.Add(expense);

            return Ok(expense);
        }

        [HttpGet]
        public async Task<IActionResult> GetByUser(string userId)
        {
            var expenses = await _expensesDAL.GetByUser(userId);

            return Ok(expenses);
        }
    }
}

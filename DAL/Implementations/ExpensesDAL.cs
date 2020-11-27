using DAL.DataContext;
using DAL.Interfaces;
using DTO.Money;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ExpensesDAL : IExpensesDAL
    {
        private readonly AppDbContext _ctx;

        public ExpensesDAL(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<ExpensesDTO> Add(ExpensesDTO model)
        {
            using(_ctx)
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
                _ctx.Expense.Add(expense);
                _ctx.SaveChanges();

                return expense;
            }
        }

        public async Task<ExpensesDTO> Get(int expenseId)
        {
            var expense = await _ctx.Expense.FirstOrDefaultAsync(x => x.Id == expenseId);

            return expense;
        }

        public async Task<ExpensesDTO> Edit(int expenseId, ExpensesDTO model)
        {
            var result = _ctx.Expense.FirstOrDefaultAsync(x => x.Id == expenseId).Result;

            if(result != null)
            {
                result.Amount = model.Amount;
                result.Id = model.Id;
                result.OutcomeDate = model.OutcomeDate;
                result.Title = model.Title;
                result.Type = model.Type;
                result.UserId = model.UserId;

                _ctx.SaveChanges();
            }

            return model;
        }

        public async Task<List<ExpensesDTO>> GetByUser(string userId)
        {
            using(_ctx)
            {
                var expenses = await _ctx.Expense.Where(x => x.UserId == userId).ToListAsync();
                return expenses;
            } 
        }
    }
}

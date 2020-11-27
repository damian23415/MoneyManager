using DTO.Money;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IExpensesDAL
    {
        public Task<ExpensesDTO> Add(ExpensesDTO model);
        public Task<ExpensesDTO> Get(int expenseId);
        public Task<ExpensesDTO> Edit(int expenseId, ExpensesDTO model);
        public Task<List<ExpensesDTO>> GetByUser(string userId);
    }
}

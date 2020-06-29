using DTO.Money;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIncomeDAL
    {
        public Task<IncomeDTO> Add(string userId);
        public Task<IncomeDTO> Get(int incomeId);
        public Task<IncomeDTO> Edit(int incomeId);
    }
}

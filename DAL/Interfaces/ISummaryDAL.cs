using DTO.Money;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISummaryDAL
    {
        public Task<SummaryDTO> Get(int sumId);
        public Task<List<SummaryDTO>> GetByUser(string userId);
        public Task<SummaryDTO> GenerateSum();
    }
}

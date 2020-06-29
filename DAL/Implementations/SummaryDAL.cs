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
    public class SummaryDAL : ISummaryDAL
    {
        private readonly AppDbContext _ctx;
        public SummaryDAL(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<SummaryDTO> AddSum(SummaryDTO model)
        {
            using(_ctx)
            {
                var summary = new SummaryDTO()
                {
                    UserId = model.UserId,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    Bilance = model.Bilance,
                };
                _ctx.Summary.Add(summary);
                _ctx.SaveChanges();

                return summary;
            }
        }

        public async Task<SummaryDTO> Get(int sumId)
        {
            using(_ctx)
            {
                var summary = await _ctx.Summary.FirstOrDefaultAsync(x => x.Id == sumId);
                return summary;
            }
        }

        public async Task<List<SummaryDTO>> GetByUser(string userId)
        {
            using (_ctx)
            {
                var userSummary = await _ctx.Summary.Where(x => x.UserId == userId).ToListAsync();
                return userSummary;
            }
        }
    }
}

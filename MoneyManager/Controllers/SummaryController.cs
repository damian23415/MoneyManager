using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO.Money;
using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        
        private readonly ISummaryDAL _summaryDAL;
        private readonly SummaryDTO _summaryDTO;

        public SummaryController(ISummaryDAL summaryDAL, SummaryDTO summaryDTO)
        {
            _summaryDAL = summaryDAL;
            _summaryDTO = summaryDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetSummary(int id)
        {
            var summary = await _summaryDAL.Get(id);

            return Ok(summary);
        }

        [HttpGet]
        public async Task<IActionResult> GetSummaryByUser(string userId)
        {
            var summary = await _summaryDAL.GetByUser(userId);

            return Ok(summary);
        }

        [HttpPost]
        public async Task<IActionResult> AddSum(SummaryDTO model)
        {
            var summary = new SummaryDTO()
            {
                Bilance = model.Bilance,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                UserId = model.UserId
            };

            await _summaryDAL.AddSum(summary);

            return Ok(summary);
        }
    }
}
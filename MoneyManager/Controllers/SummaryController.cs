using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoneyManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        
        private readonly ISummaryDAL _summaryDAL;

        public SummaryController(ISummaryDAL summaryDAL)
        {
            _summaryDAL = summaryDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetSummary(int id)
        {
            var summary = await _summaryDAL.Get(id);

            return Ok(summary);
        }
    }
}
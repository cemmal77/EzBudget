using EzBudget.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace EzBudget.Api.Controllers
{
    [ApiController]
    [Route("BudgetSummaries")]
    public class BudgetSummariesController : Controller
    {
        private readonly IBudgetSummariesDataProcessor budgetSummariesDataProcessor;

        public BudgetSummariesController(IBudgetSummariesDataProcessor budgetSummariesDataProcessor)
        {
            this.budgetSummariesDataProcessor = budgetSummariesDataProcessor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.budgetSummariesDataProcessor.Read());
        }
    }
}

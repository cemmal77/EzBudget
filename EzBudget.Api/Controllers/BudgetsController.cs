using EzBudget.Api.Data;
using EzBudget.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EzBudget.Api.Controllers
{
    [ApiController]
    [Route("Budgets")]
    public class BudgetsController : Controller
    {
        private readonly IBudgetDataProcessor budgetDataProcessor;
        private readonly IBudgetSummariesDataProcessor budgetSummariesDataProcessor;

        public BudgetsController(IBudgetDataProcessor budgetDataProcessor, IBudgetSummariesDataProcessor budgetSummariesDataProcessor)
        {
            this.budgetDataProcessor = budgetDataProcessor;
            this.budgetSummariesDataProcessor = budgetSummariesDataProcessor;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Budget budget)
        {
            var id = this.budgetDataProcessor.Create(budget);
            this.budgetSummariesDataProcessor.Update(new BudgetSummary(budget));
            return Created($"{Request.Scheme}://{Request.Host}/Budgets/{id}", budget);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(this.budgetDataProcessor.Read(id));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Budget budget)
        {
            this.budgetDataProcessor.Update(budget);
            this.budgetSummariesDataProcessor.Update(new BudgetSummary(budget));
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            this.budgetDataProcessor.Delete(id);
            this.budgetSummariesDataProcessor.Remove(id);

            return Ok();
        }
    }
}

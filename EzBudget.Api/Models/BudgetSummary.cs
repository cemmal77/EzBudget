using System;
using System.Linq;

namespace EzBudget.Api.Models
{
    public class BudgetSummary
    {
        public BudgetSummary() {}

        public BudgetSummary(Budget budget)
        {
            this.Id = budget.Id;
            this.Name = budget.Name;
            this.StartDate = budget?.BudgetPeriods?.OrderBy(item => item.StartDate)?.First()?.StartDate;
            this.EndDate = budget?.BudgetPeriods?.OrderByDescending(item => item.EndDate)?.First()?.EndDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

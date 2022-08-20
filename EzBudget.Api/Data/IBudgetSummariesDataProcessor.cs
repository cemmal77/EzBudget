using EzBudget.Api.Models;
using System;
using System.Collections.Generic;

namespace EzBudget.Api.Data
{
    public interface IBudgetSummariesDataProcessor
    {
        public ICollection<BudgetSummary> Read();
        public void Update(BudgetSummary budgetSummary);
        public void Remove(Guid guid);
    }
}

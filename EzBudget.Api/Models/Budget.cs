using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EzBudget.Api.Models
{
    public class Budget
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BudgetPeriod> BudgetPeriods { get; set; }
    }
}

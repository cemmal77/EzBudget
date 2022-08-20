using System;
using System.Collections.Generic;

namespace EzBudget.Api.Models
{
    public class BudgetPeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<LineItemGroup> LineItemGroups { get; set; }
    }
}

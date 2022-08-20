using System.Collections.Generic;

namespace EzBudget.Api.Models
{
    public class LineItemGroup
    {
        public string Name { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}

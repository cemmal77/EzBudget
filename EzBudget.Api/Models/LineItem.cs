using System;
using System.ComponentModel.DataAnnotations;

namespace EzBudget.Api.Models
{
    public class LineItem
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public string Category { get; set; }
    }
}

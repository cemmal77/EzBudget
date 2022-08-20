using EzBudget.Api.Models;
using System;

namespace EzBudget.Api.Data
{
    public interface IBudgetDataProcessor
    {
        public Guid Create(Budget budget);
        public Budget Read(Guid id);
        public void Update(Budget budget);
        public void Delete(Guid id);
    }
}

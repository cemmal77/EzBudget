using EzBudget.Api.Models;
using EzBudget.Data.Config;
using EzBudget.Data.Readers;
using EzBudget.Data.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EzBudget.Api.Data
{
    public class BudgetSummariesDataProcessor : IBudgetSummariesDataProcessor
    {
        private readonly IJsonReader jsonReader;
        private readonly IJsonWriter jsonWriter;
        private readonly DataAccessConfig dataAccessConfig;

        public BudgetSummariesDataProcessor(IJsonReader jsonReader, IJsonWriter jsonWriter, DataAccessConfig dataAccessConfig)
        {
            this.jsonReader = jsonReader;
            this.jsonWriter = jsonWriter;
            this.dataAccessConfig = dataAccessConfig;
        }

        public ICollection<BudgetSummary> Read()
        {
            return this.jsonReader.ReadData<ICollection<BudgetSummary>>("", "BudgetSummaries.json");
        }

        public void Update(BudgetSummary budgetSummary)
        {
            var budgetSummaries = new List<BudgetSummary>();

            if (File.Exists(Path.Combine(this.dataAccessConfig.BasePath, "BudgetSummaries.json")))
            {
                budgetSummaries = this.jsonReader.ReadData<ICollection<BudgetSummary>>("", "BudgetSummaries.json").ToList();
            }

            int index = budgetSummaries.Any() ? budgetSummaries.FindIndex(item => item.Id == budgetSummary.Id) : 0;

            budgetSummaries[index] = budgetSummary;

            this.jsonWriter.WriteData("", "BudgetSummaries.json", budgetSummaries);
        }

        public void Remove(Guid id)
        {
            ICollection<BudgetSummary> budgetSummaries = new List<BudgetSummary>();

            if (File.Exists(Path.Combine(this.dataAccessConfig.BasePath, "BudgetSummaries.json")))
            {
                budgetSummaries = this.jsonReader.ReadData<ICollection<BudgetSummary>>("", "BudgetSummaries.json");
            }

            budgetSummaries = budgetSummaries
                .Except(budgetSummaries.Where(item => item.Id == id))
                .ToList();

            this.jsonWriter.WriteData("", "BudgetSummaries.json", budgetSummaries);
        }
    }
}

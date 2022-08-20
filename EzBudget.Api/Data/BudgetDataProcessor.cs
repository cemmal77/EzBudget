using EzBudget.Api.Models;
using EzBudget.Data.Config;
using EzBudget.Data.Readers;
using EzBudget.Data.Writers;
using System;
using System.IO;
using System.Linq;

namespace EzBudget.Api.Data
{
    public class BudgetDataProcessor : IBudgetDataProcessor
    {
        private readonly IJsonReader jsonReader;
        private readonly IJsonWriter jsonWriter;
        private readonly DataAccessConfig dataAccessConfig;

        public BudgetDataProcessor(IJsonReader jsonReader, IJsonWriter jsonWriter, DataAccessConfig dataAccessConfig)
        {
            this.jsonReader = jsonReader;
            this.jsonWriter = jsonWriter;
            this.dataAccessConfig = dataAccessConfig;
        }

        public Guid Create(Budget budget)
        {
            budget.Id = Guid.NewGuid();

            this.jsonWriter.WriteData<Budget>("Budgets", NameJsonFile(budget.Id.ToString()), budget);

            return budget.Id;
        }

        public Budget Read(Guid id)
        {
            return this.jsonReader.ReadData<Budget>("Budgets", NameJsonFile(id.ToString()));
        }

        public void Update(Budget budget)
        {
            if (budget.Id.IsNullOrEmpty()) throw new InvalidDataException("Missing Id");

            this.jsonWriter.WriteData<Budget>("Budgets", NameJsonFile(budget.Id.ToString()), budget);
        }

        public void Delete(Guid id)
        {
            File.Delete(Path.Combine(this.dataAccessConfig.BasePath, "Budgets", NameJsonFile(id.ToString())));
        }

        private string NameJsonFile(string s)
        {
            return $"{s}.json";
        }
    }
}

using System.Collections.Generic;

namespace EzBudget.Data.Readers
{
    public interface IJsonReader
    {
        public T ReadData<T>(string filePath, string fileName);
    }
}

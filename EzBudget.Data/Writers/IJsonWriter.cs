namespace EzBudget.Data.Writers
{
    public interface IJsonWriter
    {
        public void WriteData<T>(string filePath, string fileName, T data);
    }
}

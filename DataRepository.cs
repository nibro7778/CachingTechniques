namespace CachingTechniques
{
    public class DataRepository : IDataRepository
    {
        private static readonly IEnumerable<Data> Data = new[]
        {
            new Data()
            {
                FirstName = "Alex",
                LastName = "Smith",
                Age = 38
            },
            new Data() 
            {
                FirstName = "John",
                LastName = "Mock",
                Age = 48
            },
            new Data()
            {
                FirstName = "Max",
                LastName = "Galen",
                Age = 38
            }
        };

        public IEnumerable<Data> GetData()
        {
            return Data;
        }
    }
}

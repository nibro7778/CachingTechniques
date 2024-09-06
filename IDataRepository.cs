namespace CachingTechniques
{
    public interface IDataRepository
    {
        IEnumerable<Data> GetData();
    }
}

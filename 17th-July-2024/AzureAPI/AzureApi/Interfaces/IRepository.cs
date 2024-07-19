namespace AzureApi.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(K key);

        Task<T> DeleteAsync(K key);

        Task<T> Add(T obj);

        Task<T> Update(T obj);
    }
}

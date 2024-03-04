namespace Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task InsertAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}

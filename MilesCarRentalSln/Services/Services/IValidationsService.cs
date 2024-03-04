namespace Services.Services
{
    public interface IValidationsService<T> where T : class
    {
        bool ValidBeforeInsert(T entity);
    }
}

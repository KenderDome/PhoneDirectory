namespace PhoneDirectory.Server.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}

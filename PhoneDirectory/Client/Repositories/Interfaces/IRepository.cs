using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(string url);

        Task<List<TEntity>> GetAll(string url);
    }
}

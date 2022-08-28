using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IRestService restService;

        public Repository(IRestService restService)
        {
            this.restService = restService;
        }
        public async Task<TEntity> Get(string url)
        {
            return await restService.GetAsync<TEntity>(url);
        }

        public async Task<List<TEntity>> GetAll(string url)
        {
            return await restService.GetAsync<List<TEntity>>(url);
        }

    }
}

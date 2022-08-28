using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Server.Repositories.Interfaces;

namespace PhoneDirectory.Server.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext context;
        private DbSet<TEntity> table;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.table = context.Set<TEntity>();
        }

        public async Task<TEntity?> Get(int id)
        {
            return await table.FindAsync(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return this.table.AsEnumerable();
        }
    }
}

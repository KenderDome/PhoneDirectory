using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Repositories
{
    public class EmployeeTypeRepository : Repository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

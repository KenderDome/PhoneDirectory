using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories
{
    public class EmployeeTypeRepository : Repository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(IRestService restService) : base(restService)
        {
        }

        public async Task<List<EmployeeType>> GetAll()
        {
            return await GetAll("employeetype/getall");
        }
    }
}

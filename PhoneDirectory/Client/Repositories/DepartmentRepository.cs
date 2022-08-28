using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(IRestService restService) : base(restService)
        {
        }

        public async Task<List<Department>> GetAll()
        {
            return await GetAll("department/getall");
        }

        public async Task<List<Employee>> GetEmployees(string name)
        {
            var result = await restService.GetAsync<List<Employee>>($"department/getemployees/{name}");

            return result;
        }
    }
}

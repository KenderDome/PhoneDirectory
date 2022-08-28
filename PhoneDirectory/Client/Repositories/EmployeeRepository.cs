using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IRestService restService) : base(restService)
        {

        }

        public async Task Update(Employee employee)
        {
            await restService.PutAsync<Employee>("employee/update", employee);
        }
        public async Task Delete(int id)
        {
           await restService.DeleteAsync($"employee/delete?id={id}");
        }
        public async Task<List<Employee>> GetAll()
        {
            return await GetAll("employee/getall");
        }
        public async Task Add(Employee employee)
        {
            await restService.PostAsync<Employee>("employee/add", employee);
        }

        public async Task<List<Employee>> Search(string searchTerm)
        {
            return await restService.GetAsync<List<Employee>>($"employee/search?searchTerm={searchTerm}");
        }

        public async Task<Employee> Get(int id)
        {
            return await Get($"employee/find?id={id}");
        }
    }
}

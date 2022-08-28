using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task Delete(int id);
        Task<Employee> Get(int id);
        public Task<List<Employee>> GetAll();
        Task<List<Employee>> Search(string searchTerm);
        Task Update(Employee employee);
    }
}

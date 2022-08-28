using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task Add(Employee employee);
        Task Delete(int id);
        Task<Employee?> Find(int id);
        IEnumerable<Employee> Search(string searchTerm);
        Task Update(Employee employee);
    }
}

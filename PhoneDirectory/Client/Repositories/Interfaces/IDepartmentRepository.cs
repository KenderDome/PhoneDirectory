using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<List<Department>> GetAll();
        Task<List<Employee>> GetEmployees(string name);
    }
}

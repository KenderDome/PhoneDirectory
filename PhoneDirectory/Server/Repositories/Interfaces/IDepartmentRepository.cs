using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Employee> GetEmployees(string name);
    }
}

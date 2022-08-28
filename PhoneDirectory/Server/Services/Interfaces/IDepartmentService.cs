using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        IEnumerable<Employee> GetEmployees(string name);
    }
}

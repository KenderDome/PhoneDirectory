using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Employee> GetEmployees(string name)
        {
            return context.Employees.Include(i=>i.EmployeeType).Where(w => w.Departments.Any(d => d.Name == name));
        }
    }
}

using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }

        public IEnumerable<Employee> GetEmployees(string name)
        {
            return departmentRepository.GetEmployees(name);
        }

       
    }
}

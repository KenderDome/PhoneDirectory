using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository employeeTypeRepository;

        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository)
        {
            this.employeeTypeRepository = employeeTypeRepository;
        }
        public Task<EmployeeType?> Get(int id)
        {
            return employeeTypeRepository.Get(id);
        }

        public IEnumerable<EmployeeType?> GetAll()
        {
            return employeeTypeRepository.GetAll();
        }
    }
}

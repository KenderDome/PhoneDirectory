using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories.Interfaces
{
    public interface IEmployeeTypeRepository : IRepository<EmployeeType>
    {
        Task<List<EmployeeType>> GetAll();

        
    }
}

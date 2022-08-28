using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Repositories.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        Task<EmployeeType?> Get(int id);
        public IEnumerable<EmployeeType> GetAll();
    }
}

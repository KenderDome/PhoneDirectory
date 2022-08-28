using PhoneDirectory.Shared.Entities;
using System.Collections;

namespace PhoneDirectory.Server.Services.Interfaces
{
    public interface IEmployeeTypeService
    {
        Task<EmployeeType?> Get(int id);

        IEnumerable<EmployeeType?> GetAll();
    }
}

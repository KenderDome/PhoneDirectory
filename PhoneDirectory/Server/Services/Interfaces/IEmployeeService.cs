using PhoneDirectory.Shared.Entities;
using System.Collections.Generic;

namespace PhoneDirectory.Server.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task Delete(int id);
        Task<Employee?> Find(int id);
        Task<Employee?> Get(int id);
        public IEnumerable<Employee> GetAll();
        IEnumerable<Employee> Search(string searchTerm);
        Task Update(Employee employee);
    }
}

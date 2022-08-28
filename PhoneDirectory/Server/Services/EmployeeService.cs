using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;
using System.Collections.Generic;

namespace PhoneDirectory.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task Delete(int id) 
        {
            await employeeRepository.Delete(id);
        }

        public async Task Add(Employee employee)
        {
            await employeeRepository.Add(employee);
        }


        public async Task Update(Employee employee)
        {
            await employeeRepository.Update(employee);
        }

        public async Task<Employee?> Get(int id)
        {
            Employee? employee = await employeeRepository.Get(id);

            if(employee != null)
            {
                if (employee.EmployeeType != null)
                {
                    employee.EmployeeType.Employee = null;
                }

                if (employee.Departments != null)
                {
                    foreach (var department in employee.Departments)
                    {
                        department.Employees = null;
                    }
                }
            }

            return employee;
        }

        public async Task<Employee?> Find(int id)
        {
            return await employeeRepository.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees =  employeeRepository.GetAll();

            foreach (var employee in employees)
            {
                if (employee.EmployeeType != null)
                    employee.EmployeeType.Employee = null;
            }

            return employees;

        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            IEnumerable<Employee> employees = employeeRepository.Search(searchTerm);

            foreach (var employee in employees)
            {
                if(employee.EmployeeType != null)
                    employee.EmployeeType.Employee = null;
            }

            return employees;
        }
    }
}

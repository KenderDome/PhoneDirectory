using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Server.Repositories.Interfaces;
using PhoneDirectory.Shared.Entities;
using System.Collections;
using System.Collections.Generic;

namespace PhoneDirectory.Server.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }


        public new IEnumerable<Employee> GetAll()
        {
            return context.Employees.Include(i => i.EmployeeType).AsEnumerable();

        }

        public async Task Delete(int id)
        {
            Employee? employee = context.Employees.Find(id);

            if (employee == null)
                throw new Exception("Employee not found!");

            context.Employees.Remove(employee);

            await context.SaveChangesAsync();
        }

        public async Task Add(Employee employee)
        {
            try
            {
                List<Department> departments = new List<Department>();

                if(employee.Departments != null)
                {
                    foreach (var department in employee.Departments)
                    {
                        departments.Add(new Department
                        {
                            DepartmentLeadId = department.DepartmentLeadId,
                            Id = department.Id,
                            Name = department.Name
                        });
                    }
                    employee.Departments = null;
                }

                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                employee.Departments = new List<Department>();

                foreach (var department in departments)
                    employee.Departments.Add(department);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public Task<Employee?> Find(int id)
        {
            return context.Employees.Include(i => i.EmployeeType).Include(i=>i.Departments).Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Employee employee)
        {
            try
            {
                var employeeToUpdate = await context.Employees.Include(i=>i.Departments).SingleAsync(s => s.Id == employee.Id);
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Phone1 = employee.Phone1;
                employeeToUpdate.Phone2 = employee.Phone2;
                employeeToUpdate.Extension = employee.Extension;
                employeeToUpdate.EmployeeTypeId = employee.EmployeeTypeId;
                employeeToUpdate.Notes = employee.Notes;
                employeeToUpdate.Email = employee.Email;

                foreach (var newDepartment in employee.Departments)
                {
                    if(!employeeToUpdate.Departments.Any(a=>a.Id == newDepartment.Id))
                        employeeToUpdate.Departments.Add(newDepartment);
                }


                for (int i = 0; i < employeeToUpdate.Departments.Count; i++)
                {
                    if (!employee.Departments.Any(a => a.Id == employeeToUpdate.Departments[i].Id))
                        employeeToUpdate.Departments.Remove(employeeToUpdate.Departments[i]);
                }
                
                await context.SaveChangesAsync();
               

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            return base.context.Employees.Include(t => t.EmployeeType)
                .Where(w => EF.Functions.Like(w.FirstName, $"%{searchTerm}%") 
                || EF.Functions.Like(w.LastName, $"%{searchTerm}%")
                || EF.Functions.Like((w.Phone1 ?? string.Empty), $"%{searchTerm}%")
                || EF.Functions.Like((w.Phone2 ?? string.Empty), $"%{searchTerm}%")
                || EF.Functions.Like(w.Extension.ToString(), $"%{searchTerm}%")).AsEnumerable();
        }

    }
}

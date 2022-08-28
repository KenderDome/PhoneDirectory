using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;
using System.Data;

namespace PhoneDirectory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpDelete("[action]")]
        public ActionResult Delete(int id)
        {
            try
            {
                employeeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public ActionResult Add([FromBody] Employee employee)
        {
            try
            {
                employeeService.Add(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public ActionResult Update([FromBody] Employee employee)
        {
            try
            {
                employeeService.Update(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public IEnumerable<Employee> GetAll()
        {
            return employeeService.GetAll().AsEnumerable();
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IEnumerable<Employee> Search(string searchTerm)
        {
            return employeeService.Search(searchTerm);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<Employee?> Find(int id)
        {
            return await employeeService.Find(id);
        }

    }
}

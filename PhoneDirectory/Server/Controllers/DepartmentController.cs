using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IEnumerable<Department> GetAll()
        {
            return departmentService.GetAll().AsEnumerable();

        }

        [HttpGet("[action]/{name}")]
        [AllowAnonymous]
        public IEnumerable<Employee> GetEmployees(string name)
        {
            return departmentService.GetEmployees(name).AsEnumerable();

        }
    }
}

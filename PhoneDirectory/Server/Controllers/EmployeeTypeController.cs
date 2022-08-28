using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Server.Services;
using PhoneDirectory.Server.Services.Interfaces;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService employeeTypeService;

        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            this.employeeTypeService = employeeTypeService;
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public IEnumerable<EmployeeType?> GetAll()
        {
            return employeeTypeService.GetAll().AsEnumerable();
        }
    }
}

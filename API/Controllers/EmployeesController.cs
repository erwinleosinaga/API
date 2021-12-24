using API.Models;
using API.Repository;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost("register")] //localhost/api/employee/register
        public ActionResult Register(RegisterVM registerVM)
        {
            try
            {
                var register = employeeRepository.Register(registerVM);
                if (register == 1)
                {
                    return Created("", new { status = "success", data = registerVM, message = "Successfully Registered" });
                }
                else
                {
                    return BadRequest(new { status = "failed", message = "unexpected error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }
        }

        [HttpGet("registered")]
        public ActionResult RegisteredData()
        {
            var registeredData = employeeRepository.GetRegisteredData();

            return Ok(new { status = "success", data = registeredData });
        }

        [HttpGet("registeredalt")]
        public ActionResult Coba()
        {
            var employeeAccount = employeeRepository.GetRegisteredDataAlt();

            return Ok(new { status = "success", data = employeeAccount });
        }
    }
}

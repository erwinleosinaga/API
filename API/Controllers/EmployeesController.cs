﻿using API.Models;
using API.Repository;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost("Register")] 
        public ActionResult Register(RegisterVM registerVM)
        {
            try
            {
                var register = employeeRepository.Register(registerVM);
                if (register == 2)
                {
                    return BadRequest(new { status = "failed", message = "duplicate email" });
                    //return Created("", new { status = "success", data = registerVM, message = "Successfully Registered" });
                }
                else if(register == 3)
                {
                    return BadRequest(new { status = "failed", message = "duplicate phones" });
                }
                else
                {
                    return Created("", new { status = "success", data = registerVM, message = "Successfully Registered" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }
        }

        //[Authorize(Roles = "Director")]
        [HttpGet("Registered")]
        public ActionResult RegisteredData()
        {
            try
            {
                var result = employeeRepository.GetRegisteredData();
                if (result == null)
                {
                    return Ok(new { status = "success", data = "no data found" });
                }

                //return Ok(new { status = "success", data = registeredData });
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }

        }

        [HttpGet("Registered/{NIK}")]
        public ActionResult RegisteredDataByNik(string NIK)
        {
            try
            {
                var registeredData = employeeRepository.GetRegisteredDataByNIK(NIK);
                if (registeredData == null)
                {
                    return NotFound();
                }

                //return Ok(new { status = "success", data = registeredData });
                return Ok(registeredData);
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }

        }


        [HttpDelete("Registered/{nik}")]
        public ActionResult DeleteRegistered(string nik)
        {
            try
            {
                var delete = employeeRepository.DeleteRegistered(nik);
                if (delete == 2)
                {
                    return NotFound(new
                    {
                        status = "failed",
                        message = "Record not found"
                    });
                }
                if (delete > 0)
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "record successfuly deleted"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        status = "failed",
                        message = "bad request"
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    status = "failed",
                    message = "bad request " + e
                });
            }
        }

        [Authorize(Roles = "Director")]
        [HttpGet("Registeredalt")]
        public ActionResult Coba()
        {
            try
            {
                var registeredData = employeeRepository.GetRegisteredDataAlt();
                if (registeredData == null)
                {
                    return Ok(new { status = "success", data = "no data found" });
                }
                return Ok(new { status = "success", data = registeredData });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }

        }

        [HttpGet("GenderStat")]
        public ActionResult GenderStat()
        {
            try
            {
                var data = employeeRepository.GetGenderStat();
                if (data == null)
                {
                    return Ok(new { status = "success", data = "no data found" });
                }

                return Ok(new { status = "success", data = data });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "failed", message = e });
            }
        }

        [HttpGet("TestCORS")]
        public ActionResult TestCORS()
        {
            return Ok("Test CORS Berhasil");
        }
    }
}

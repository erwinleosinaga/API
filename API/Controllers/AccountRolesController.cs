using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AccountRolesController : BaseController<AccountRole, AccountRoleRepository, string>
    {
        private AccountRoleRepository accountRoleRepository;
        public AccountRolesController(AccountRoleRepository accountRoleRepository) : base(accountRoleRepository)
        {
            this.accountRoleRepository = accountRoleRepository;
        }

        [Authorize(Roles = "Director")]
        [HttpGet("SignManager/{nik}")]
        public ActionResult SignManager(string nik)
        {
            var assign = accountRoleRepository.SignManager(nik);
            if (assign == 2)
            {
                return Conflict(new { status = "failed", message = "this account are already a manager" });
            }
            if (assign == 1)
            {
                return Ok(new { status = "success", message = "this account registered as manager" });
            }
            else
            {
                return BadRequest(new { status = "failed", message = "unknown error" });
            }
        }
    }
}

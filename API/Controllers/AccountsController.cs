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
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = accountRepository.Login(loginVM.Email, loginVM.Password);

            if (login == 2)
            {
                return Unauthorized(new { status = "failed", message = "Akun tidak ditemukan" });
            }
            if (login == 3)
            {
                return Unauthorized(new { status = "failed", message = "Password salah" });
            }
            if (login == 1)
            {
                return Ok(new { status = "success", message = "Successfuly logged in" });
            }
            else
            {
                return BadRequest(new { status = "failed", message = "Unknown error" });
            }
        }
    }
}

using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Login(string email, string password)
        {
            var checkData = (from employee in myContext.Set<Employee>()
                            where employee.Email == email
                            join account in myContext.Set<Account>()
                                on employee.NIK equals account.NIK
                            select new
                            {
                                employee.NIK,
                                employee.Email,
                                account.Password
                            }).FirstOrDefault();
            //check email di tabel employee dan nik di tabel account
            if (checkData == null)
            {
                return 2; //Akun tidak ditemukan
            }

            // check a password
            bool validPassword = BCrypt.Net.BCrypt.Verify(password, checkData.Password);
            if (!validPassword)
            {
                return 3; //Pasword salah
            }
            else
            {
                return 1; //Berhasil login
            }
        }
    }
}

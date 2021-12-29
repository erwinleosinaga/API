using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, string>
    {
        private readonly MyContext myContext;
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int SignManager(string nik)
        {
            var checkExist = myContext.AccountRoles.Find(nik, 2);

            if (checkExist != null)
            {
                return 2; //Sudah jadi manager
            }
            var data = new AccountRole()
            {
                AccountId = nik,
                RoleId = 2
            };
            myContext.AccountRoles.Add(data);
            return myContext.SaveChanges();
        }
    }
}

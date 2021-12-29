using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_tr_accountrole")]
    public class AccountRole
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}

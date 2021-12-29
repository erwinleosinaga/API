using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_m_role")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}

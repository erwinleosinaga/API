using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_tr_account")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }
        public int OTP { get; set; }
        public DateTime ExpiredToken { get; set; }
        public bool IsUsed { get; set; }
        //[JsonIgnore]
        public virtual Employee Employee { get; set; }
        //[JsonIgnore]
        public virtual Profiling Profiling { get; set; }
    }
}

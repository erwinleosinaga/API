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
        [Required]
        public string Password { get; set; }
        //[JsonIgnore]
        public virtual Employee Employee { get; set; }
        //[JsonIgnore]
        public virtual Profiling Profiling { get; set; }
    }
}

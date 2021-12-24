using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_m_university")]
    public class University
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Education> Educations { get; set; }
    }
}

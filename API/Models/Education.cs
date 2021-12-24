using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_m_education")]
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        [Required]
        public double GPA { get; set; }
        [Required]
        public int UniversityId { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Profiling> Profilings { get; set; }
        //[JsonIgnore]
        public virtual University University { get; set; }
    }
}

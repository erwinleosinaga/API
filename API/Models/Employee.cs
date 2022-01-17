using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace API.Models
{
    [Table("tb_m_employee")] //nama tabel
    public class Employee
    {
        [Key] //primary key
        public string NIK { get; set; } 
        [Required(ErrorMessage = "First Name is required")] 
        [MinLength(3, ErrorMessage = "First Name(minimum 3 char)")] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")] //wajib
        [Phone(ErrorMessage = "Please input correct Phone Number Format")] //format nomor telepon
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(0, 500000000)]
        public int Salary { get; set; }
        [EmailAddress] // Harus format email
        public string Email { get; set; }
    //    [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        public virtual Account Account { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_m_employee")] // Assign nama tabel
    public class Employee
    {
        [Key] //Assign primary key
        public string NIK { get; set; } //NIK
        [Required(ErrorMessage = "First Name is required")] //wajib
        [MinLength(3, ErrorMessage = "First Name(minimum 3 char)")] //min lenght
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")] //wajib
        [Phone(ErrorMessage = "Please input correct Phone Number Format")] //format nomor telepon
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Range(0, 500000000)] //Harus pada rentang Rp0 hingg Rp500juta
        public int Salary { get; set; }
        [EmailAddress] // Harus format email
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public virtual Account Account { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

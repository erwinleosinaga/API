using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModels
{
    public class ChangePasswordVM
    {
        //Data validation seperti [Required] bisa juga ditambahkan di sini
        public string NIK { get; set; }
        public int OTP { get; set; }
        public string NewPassword { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModels
{
    public class LoginDataVM
    {
        [Required][EmailAddress]
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}

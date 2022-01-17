using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class JWTokenVM
    {
        public string status { get; set; }
        public string idToken { get; set; }
        public string message { get; set; }
    }
}

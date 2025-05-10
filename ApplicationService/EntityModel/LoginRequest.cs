using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
        public string devicename { get; set; }
        public string ipaddress { get; set; }
    }
}

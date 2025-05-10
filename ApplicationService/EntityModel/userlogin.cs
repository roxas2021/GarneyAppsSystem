using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class userlogin
    {
        public int Id { get; set; }
        public int userid { get; set; }
        public string password { get; set; }
        public string authtoken { get; set; }
        public string devicename { get; set; }
        public string ipaddress { get; set; }
        public DateTime createdat { get; set; }
        public DateTime lastusedat { get; set; }
    }
}

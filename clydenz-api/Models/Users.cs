using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clydenz_api.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; } // 1- authorised, 0- unauthorised
    }
}

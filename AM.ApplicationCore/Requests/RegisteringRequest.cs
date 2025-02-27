using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Requests
{
    public class RegisteringRequest
    {

        public string Email { get; set; }


        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public string Password { get; set; }
    }

}

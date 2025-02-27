using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Requests
{
    public record LoginRequest
    {
        public required string email {  get; set; }
        public required string password { get; set; }
    }
}

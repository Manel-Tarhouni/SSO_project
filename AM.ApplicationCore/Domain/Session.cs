using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Session
    {
        public Guid SessionID { get; set; }
        public string IdpName { get; set; }
    }
}

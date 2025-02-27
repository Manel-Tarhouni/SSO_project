using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AM.ApplicationCore.Domain
{
    public class User:IdentityUser<Guid>
    {
        [Required,StringLength(20)]
        public string Firstname { get; set; }

        [Required, StringLength(20)]
        public string Lastname { get; set; }
        
        public virtual List<Application> Applications { get; set; }
        public virtual List<Role> Roles { get; set; }

        public virtual List<Token> Tokens { get; set; }


    }
}

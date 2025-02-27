using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class User
    {
        
        public Guid UserId { get; set; }
        [Required,StringLength(20)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]   
         public string Email { get; set; }
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)] 
        public string Password { get; set; }
        
        public virtual List<Application> Applications { get; set; }
        public virtual List<Role> Roles { get; set; }

        public virtual List<Token> Tokens { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Application
    {
        [Key]
        public Guid ClientId { get; set; }
        [Required]
        public Guid ClientSecret { get; set; }
        [Required, StringLength(40)]
        public string Redirect_Uri { get; set; }
        [Required]
        public List<string> Allowed_Scopes  { get; set; }
        [Required]
        public string Domain {  get; set; }

        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }  
        
        
    }
}

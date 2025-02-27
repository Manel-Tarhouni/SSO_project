using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public List<Permission> Permissions { get; set; }

        public virtual List<User> Users { get; set; }


    }
}

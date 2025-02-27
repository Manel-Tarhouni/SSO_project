using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Type_token
{
   id_token,
   access_token,
   logout_token,
   refresh_token

}
namespace AM.ApplicationCore.Domain
{
    public class Token
    {
        [Key]
        public Guid TokenId { get; set; }
        public Type_token type { get; set; }
        public string TokenValue { get; set; }
       [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
 
        public List<string> scopes { get; set; }

        public virtual Guid UserId { get; set; }
       // [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}

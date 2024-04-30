using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemeaseWeb.Models.tables
{
    [Table("UserAccount", Schema = "dbo")]
    public class UserAccount
    {
        
        public string UserPassword { get; set; }
        [Key]
        public string UserName { get; set; }
  
    }
}

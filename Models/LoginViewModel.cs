using System.ComponentModel.DataAnnotations;

namespace ChemeaseWeb.Models
{
    public class LoginViewModel
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

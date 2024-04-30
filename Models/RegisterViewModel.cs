
using System.ComponentModel.DataAnnotations;

namespace ChemeaseWeb.Models
{
    public class RegisterViewModel
    {
        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

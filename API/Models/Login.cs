using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace API.Models
{
    
    public class Login
    {
        [Required(ErrorMessage = "Email Requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Requerido")]
        public string Pass { get; set; }
    }
}

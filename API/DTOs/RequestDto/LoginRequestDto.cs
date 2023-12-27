using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RequestDto
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "UserName is necessary!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is necessary!")]
        public string Password { get; set; }
    }
}
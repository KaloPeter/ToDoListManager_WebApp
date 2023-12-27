using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RequestDto
{
    public class UserRegisterRequestDto
    {
        [Required(ErrorMessage = "FirstName is neccessery!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is neccessery!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is neccessery!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is neccessery!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is neccessery!")]
        public string Password { get; set; }
    }
}
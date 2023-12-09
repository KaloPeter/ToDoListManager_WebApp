namespace API.DTOs.ResponseDto
{
    public class RoleResponseDto
    {
        public string RoleName { get; set; }
        public ICollection<UserResponseDto> Users { get; set; }
    }
}
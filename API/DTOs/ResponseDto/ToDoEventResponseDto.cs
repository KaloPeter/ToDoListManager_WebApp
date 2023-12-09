namespace API.DTOs.ResponseDto
{
    public class ToDoEventResponseDto
    {
        public string ToDoEventName { get; set; }
        public string ToDoEventDescription { get; set; }
        public DateOnly EventDate { get; set; }
        public UserResponseDto User { get; set; }

    }
}
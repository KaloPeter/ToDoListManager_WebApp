namespace API.DTOs.ResponseDto
{
    public class ToDoSingleEventResponseDto
    {
        public string ToDoSingleEventName { get; set; }
        public string ToDoSingleEventDescription { get; set; }

        public int SingleEventImportance { get; set; }
        public DateOnly SingleEventDate { get; set; }
        public UserResponseDto User { get; set; }

        //      public string ToDoSingleEventImageUrl { get; set; }

    }
}
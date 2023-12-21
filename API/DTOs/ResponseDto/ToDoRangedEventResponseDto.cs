namespace API.DTOs.ResponseDto
{
    public class ToDoRangedEventResponseDto
    {

        public string ToDoRangedEventName { get; set; }
        public string ToDoRangedEventDescription { get; set; }

        public int RangedEventImportance { get; set; }

        public DateOnly RangedEventStartDate { get; set; }
        public DateOnly RangedEventEndDate { get; set; }

        public UserResponseDto User { get; set; }
    }
}
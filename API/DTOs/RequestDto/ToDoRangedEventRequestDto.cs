namespace API.DTOs.RequestDto
{
    public class ToDoRangedEventRequestDto
    {
        public string ToDoRangedEventName { get; set; }
        public string ToDoRangedEventDescription { get; set; }

        public int RangedEventImportance { get; set; }
        public DateOnly RangedEventStartDate { get; set; }
        public DateOnly RangedEventEndDate { get; set; }
    }
}
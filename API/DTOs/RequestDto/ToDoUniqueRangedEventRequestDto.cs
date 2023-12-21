namespace API.DTOs.RequestDto
{
    public class ToDoUniqueRangedEventRequestDto
    {
        public string ToDoRangedEventName { get; set; }

        public int RangedEventImportance { get; set; }
        public DateOnly RangedEventStartDate { get; set; }
        public DateOnly RangedEventEndDate { get; set; }
    }
}
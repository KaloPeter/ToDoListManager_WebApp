namespace API.DTOs.RequestDto
{
    public class ToDoSingleEventRequestDto
    {
        public string ToDoSingleEventName { get; set; }
        public string ToDoSingleEventDescription { get; set; }

        public int SingleEventImportance { get; set; }
        public DateOnly SingleEventDate { get; set; }
    }
}
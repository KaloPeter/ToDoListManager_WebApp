namespace API.DTOs.RequestDto
{
    public class ToDoUniqueSingleEventRequestDto
    {
        public string ToDoSingleEventName { get; set; }
        public int SingleEventImportance { get; set; }
        public DateOnly SingleEventDate { get; set; }
    }
}
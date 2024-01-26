using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RequestDto
{
    public class ToDoSingleEventRequestDto
    {
        [Required(ErrorMessage = "Single EventName is necessary!")]
        public string ToDoSingleEventName { get; set; }
        [Required(ErrorMessage = "Single EventDescription is necessary!")]
        public string ToDoSingleEventDescription { get; set; }
        [Required]
        public int SingleEventImportance { get; set; }
        [Required]
        public DateOnly SingleEventDate { get; set; }
        //     public IFormFile ToDoImage { get; set; }
    }
}
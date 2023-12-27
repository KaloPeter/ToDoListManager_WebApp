using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RequestDto
{
    public class ToDoRangedEventRequestDto
    {
        [Required(ErrorMessage = "Ranged EventName is necessary!")]
        public string ToDoRangedEventName { get; set; }
        [Required(ErrorMessage = "Ranged EventDescription is necessary!")]
        public string ToDoRangedEventDescription { get; set; }
        [Required]
        public int RangedEventImportance { get; set; }
        [Required]
        public DateOnly RangedEventStartDate { get; set; }
        [Required]
        public DateOnly RangedEventEndDate { get; set; }
    }
}
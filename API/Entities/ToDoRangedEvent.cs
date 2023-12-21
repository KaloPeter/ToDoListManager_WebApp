using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ToDoRangedEvent
    {
        public ToDoRangedEvent()
        {
            ToDoRangedEventId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ToDoRangedEventId { get; set; }
        public string ToDoRangedEventName { get; set; }
        public string ToDoRangedEventDescription { get; set; }

        public int RangedEventImportance { get; set; }
        public DateOnly RangedEventStartDate { get; set; }
        public DateOnly RangedEventEndDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
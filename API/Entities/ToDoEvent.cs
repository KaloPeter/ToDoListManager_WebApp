using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ToDoEvent
    {
        public ToDoEvent()
        {
            ToDoEventId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ToDoEventId { get; set; }
        public string ToDoEventName { get; set; }
        public string ToDoEventDescription { get; set; }
        public DateOnly EventDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }



    }
}
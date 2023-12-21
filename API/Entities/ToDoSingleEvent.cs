using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ToDoSingleEvent
    {
        public ToDoSingleEvent()
        {
            ToDoEventId = Guid.NewGuid().ToString();
        }

        [Key]
        public string ToDoEventId { get; set; }
        public string ToDoSingleEventName { get; set; }
        public string ToDoSingleEventDescription { get; set; }
        public int SingleEventImportance { get; set; }
        public DateOnly SingleEventDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }



    }
}
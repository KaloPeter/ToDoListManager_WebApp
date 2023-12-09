using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }

    }
}
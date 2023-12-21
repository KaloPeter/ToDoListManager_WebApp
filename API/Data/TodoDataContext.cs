using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TodoDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToDoSingleEvent> ToDoSingleEvents { get; set; }
        public DbSet<ToDoRangedEvent> ToDoRangedEvents { get; set; }

        public TodoDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
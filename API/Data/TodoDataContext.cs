using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TodoDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToDoEvent> ToDoEvents { get; set; }

        public TodoDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
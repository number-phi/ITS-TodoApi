using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoApi.Data.Entities;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    }
}

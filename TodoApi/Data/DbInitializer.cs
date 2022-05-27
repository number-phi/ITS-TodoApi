using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TodoApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {

                if (!context.TodoItems.Any())
                {
                    context.TodoItems.AddRange(
                        new Entities.TodoItem
                        {
                            Name = "Item 1",
                            IsCompleted = false
                        },
                        new Entities.TodoItem
                        {
                            Name = "Item 2",
                            IsCompleted = false
                        }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}

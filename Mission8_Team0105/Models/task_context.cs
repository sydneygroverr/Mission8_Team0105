using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Mission8_Team0105.Models
{
    public class task_context: DbContext
    {
            public task_context(DbContextOptions<task_context> options) : base(options)
            {
            }
            
            public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(
                 new Task { TaskId = 1, TaskName = "Task 1 Name", Quadrant = 1, Category = "Home", Completed = false },
                 new Task { TaskId = 2, TaskName = "Task 2 Name", Quadrant = 2, Category = "School", Completed = false },
                 new Task { TaskId = 3, TaskName = "Task 3 Name", Quadrant = 3, Category = "Work", Completed = false },
                 new Task { TaskId = 4, TaskName = "Task 4 Name", Quadrant = 4, Category = "Church", Completed = false }
            );
        }


    }

}




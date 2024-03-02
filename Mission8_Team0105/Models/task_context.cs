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
            public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
     
            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryID = 1, CategoryName = "Home" },
                 new Category { CategoryID = 2, CategoryName = "School" },
                 new Category { CategoryID = 3, CategoryName = "Work" },
                 new Category { CategoryID = 4, CategoryName = "Church" }
            );
        }

    }

}




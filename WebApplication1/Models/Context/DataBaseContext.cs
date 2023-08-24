using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions dbContext):base(dbContext) { }
    

        public DbSet<ToDo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasQueryFilter(p => !p.IsRemoved);
        }

      

    }
}

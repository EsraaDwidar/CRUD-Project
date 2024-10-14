using Microsoft.EntityFrameworkCore;

namespace CRUD_Project.DAL
{
    public class ItemsContext : DbContext
    {
        public DbSet<Items> Items => Set<Items>();
        public ItemsContext(DbContextOptions<ItemsContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var items = new List<Items>
            {
                new Items{Id =1, Task = "item1", IsDone = true },
                new Items {Id =2, Task = "item2", IsDone = false },
                new Items {Id =3, Task = "item3", IsDone = false },
                new Items {Id =5, Task = "item5", IsDone = false }
            };
            modelBuilder.Entity<Items>().HasData(items);
        }
    }
}

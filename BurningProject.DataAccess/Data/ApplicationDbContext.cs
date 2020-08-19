using BurningProject.Models.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace BurningProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Article>()
        //         .Property(a => a.Id)
        //         .ValueGeneratedOnAdd();
        // }
        public DbSet<Article> Articles { get; set; }
        
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb_Razor.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext>options):base(options)
        {
            
        }
        public DbSet<Relative> RelativesTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relative>().HasData(
            new Relative { RelativeId = 1, RelativeName = "Sathiyamoorthy",Relationship  = "Father" },
           new Relative { RelativeId = 2, RelativeName = "Sivakami", Relationship = "Mother" },
            new Relative { RelativeId = 3, RelativeName = "Rathinam", Relationship = "Brother" },
            new Relative { RelativeId = 4, RelativeName = "Ashwin&Appu", Relationship = "Sons" }

            );
        }


    }
}

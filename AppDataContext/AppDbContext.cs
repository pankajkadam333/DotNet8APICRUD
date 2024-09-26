// AppDataContext/TodoDbContext.cs

using DotNet8API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DotNet8API.AppDataContext
{
    // TodoDbContext class inherits from DbContext
    public class AppDbContext : DbContext
    {

        // DbSettings field to store the connection string
        private readonly AppSettings _dbsettings;

        // Constructor to inject the DbSettings model
        public AppDbContext(IOptions<AppSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }


        // DbSet property to represent the Todo table
        public DbSet<OurHero> OurHero { get; set; }

        // Configuring the database provider and connection string

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
        }

        // Configuring the model for the Todo entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OurHero>()
                .ToTable("OurHero")
                .HasKey(x => x.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pilot.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Pilot.DAL
{
	public class PilotDbContext:DbContext
	{
        private readonly IConfiguration _configuration;

        public PilotDbContext(IConfiguration configuration)
		{
            this._configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poi>()
            .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("Default"));
            base.OnConfiguring(options);
        }

        public DbSet<Poi> POI { get; set; }

        public DbSet<Building> Buildings { get; set; }
    }
}



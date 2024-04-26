using Microsoft.EntityFrameworkCore;
using DataImpact.Models;

namespace DataImpact
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalInfoModel>()
                .HasKey(p => p.Id); // Configure Id property as the primary key for PersonalInfoModel
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Define DbSet properties here, representing database tables

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalInfoModel> PersonalInfo { get; set; }
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
    }
}

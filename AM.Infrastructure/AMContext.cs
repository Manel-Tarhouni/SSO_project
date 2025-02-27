using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AM.Infrastructure
{
    public class AMContext :IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
        protected readonly IConfiguration configuration;
        public AMContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
          public DbSet<User> Users { get; set; } 
          public DbSet<Application> Applications { get; set; }
          public DbSet<Role> Roles{ get; set; }

          public DbSet<Token> Tokens { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }
        // Apply all configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AM.Infrastructure
{
    public class AMContext :DbContext
    {
        protected readonly IConfiguration configuration;
        public AMContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /*  public DbSet<User> Users { get; set; } 
          public DbSet<Application> Applications { get; set; }
          public DbSet<Role> Roles{ get; set; }

          public DbSet<Token> Tokens { get; set; }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}

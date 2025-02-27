using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AM.ApplicationCore.Domain;
namespace AM.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
            builder.HasMany(u => u.Applications) 
                   .WithOne(a => a.User)         
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Roles)
          .WithMany(r => r.Users)
          .UsingEntity(j => j.ToTable("User_Roles"));
        }
    }
}

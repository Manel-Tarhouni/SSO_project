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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            
            builder.HasOne(a => a.User)  
                   .WithMany(u => u.Applications)  
                   .HasForeignKey(a => a.UserId) 
                   .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}

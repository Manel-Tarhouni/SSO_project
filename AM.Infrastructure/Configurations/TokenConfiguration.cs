using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.Configurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(t => t.TokenId);

            builder.HasOne(t => t.User)
                   .WithMany(u => u.Tokens)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: cascade delete
        }
    }
}

using Core.Model.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Email)
                .HasMaxLength(50);

            
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();


            builder.Ignore(x => x.UserName)
                .Ignore(x=>x.AccessFailedCount)
                .Ignore(x=>x.LockoutEnabled)
                .Ignore(x=>x.LockoutEnd)
                .Ignore(x=>x.TwoFactorEnabled);

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Photo)
                .HasColumnType("image");

            builder.Property(x => x.Address)
                .HasMaxLength(200);

            builder.ToTable("Users");

        }
    }
}

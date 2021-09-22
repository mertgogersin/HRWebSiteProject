using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class BonusConfiguration : IEntityTypeConfiguration<Bonus>
    {
        public void Configure(EntityTypeBuilder<Bonus> builder)
        {
            builder.HasKey(x => x.BonusID);
                

            builder.Property(x => x.BonusAmount)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.ToTable("Bonuses");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bonuses)
                .HasForeignKey(x => x.UserID);
        }
    }
}

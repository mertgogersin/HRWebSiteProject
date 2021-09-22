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
    public class DebitConfiguration : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.HasKey(x => x.DebitID);

            builder.Property(x => x.ProductName)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.ToTable("Debits");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Debits)
                .HasForeignKey(x => x.UserID);

        }
    }
}

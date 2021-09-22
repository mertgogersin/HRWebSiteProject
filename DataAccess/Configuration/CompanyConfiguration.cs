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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyID);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Address)
                .HasMaxLength(200);

            builder.Property(x => x.Logo)
                .HasColumnType("varbinary");

            builder.Property(x => x.Comment)
                .HasMaxLength(1500);

            builder.ToTable("Companies");

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.PlanID);

        }
    }
}

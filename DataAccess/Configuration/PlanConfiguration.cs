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
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(x => x.PlanID);

            builder.Property(x => x.PlanName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.ToTable("Plan");
        }
    }
}

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
    public class DayOffConfiguration : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder.HasKey(x => x.DayOffID);

            builder.Property(x => x.Title)
                .HasMaxLength(150);

            builder.ToTable("DayOff");
        }
    }
}

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
    public class UserShiftConfiguration : IEntityTypeConfiguration<UserShift>
    {
        public void Configure(EntityTypeBuilder<UserShift> builder)
        {

            builder.HasKey(x => new { x.Shift, x.User });

            builder.ToTable("UserShifts");
        }
    }
}

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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = Guid.NewGuid(), Name = "Employer", NormalizedName = "EMPLOYER" });
            builder.HasData(new Role { Id = Guid.NewGuid(), Name = "Employee", NormalizedName = "EMPLOYEE" });
        }
    }
}

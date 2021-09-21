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
            throw new NotImplementedException();
        }
    }
}

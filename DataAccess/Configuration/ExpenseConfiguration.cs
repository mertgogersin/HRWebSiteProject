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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.ExpenseID);

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.TotalPrice)
                .IsRequired();

            builder.ToTable("Expenses");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.UserID);
        }
    }
}

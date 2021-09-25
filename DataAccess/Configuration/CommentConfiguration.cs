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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentID);

            builder.Property(x => x.CommentTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CommentContent)
               .IsRequired()
               .HasMaxLength(1500);

            builder.HasOne(x => x.Company)
                .WithOne(x => x.Comment)
                .HasForeignKey<Comment>(x => x.CompanyID);

            builder.ToTable("Comments");
        }

    }
}

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
    public class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.HasKey(x => x.FileTypeID);

            builder.Property(x => x.FileTypeName)
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("FileType");
        }
    }
}

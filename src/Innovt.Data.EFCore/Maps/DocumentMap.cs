﻿using Innovt.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Innovt.Data.EFCore.Maps
{
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        private readonly bool ignoreDocumentType;

        public DocumentMap(bool ignoreDocumentType=false)
        {
            this.ignoreDocumentType = ignoreDocumentType;
        }

        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable(nameof(Document));

            builder.HasKey(d => d.Id);
            builder.Property(e => e.Number).HasMaxLength(20).IsRequired();

            if (ignoreDocumentType)
            {
                builder.Ignore(d => d.DocumentType);
                builder.Ignore(d => d.DocumentTypeId);
            }
            else
            {
                builder.HasOne(d => d.DocumentType).WithMany().HasForeignKey(d => d.DocumentTypeId);
            }
        }
    }
}

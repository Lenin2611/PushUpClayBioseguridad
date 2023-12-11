using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contacto");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50); // 2611

            builder.HasOne(x => x.TipoContacto).WithMany(x => x.Contactos).HasForeignKey(x => x.IdTipoContactoFk);
        }
    }
}
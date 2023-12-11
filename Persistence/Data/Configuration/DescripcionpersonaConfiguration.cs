using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DescripcionpersonaConfiguration : IEntityTypeConfiguration<Descripcionpersona>
    {
        public void Configure(EntityTypeBuilder<Descripcionpersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("descripcionpersona");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdDireccionFk, "idDireccionFk");

            builder.HasIndex(e => e.IdPersona, "idPersona").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            
            builder.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            builder.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFk");
            builder.Property(e => e.IdPersona).HasColumnName("idPersona");
            

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Descripcionpersonas)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("descripcionpersona_ibfk_1");

            builder.HasOne(x => x.Contacto).WithMany(x => x.Descripcionpersonas)
                .HasForeignKey(x => x.IdContactoFk);
        }
    }
}
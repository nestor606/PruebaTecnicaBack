using Inmobiliaria.Infraestructura.Configuration.Entitty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Configuration.EntityConfiguration
{
    public class PropiedadesConfiguration : IEntityTypeConfiguration<Propiedad>
    {
        public void Configure(EntityTypeBuilder<Propiedad> builder)
        {
            builder.HasKey(x => x.IdPopiedad);

            builder.Property(x => x.IdPopiedad).HasColumnName("IdPopiedad").HasColumnType("int");
            builder.Property(x => x.Nombre).HasMaxLength(50).HasColumnName("Nombre").HasColumnType("varhcar");
            builder.Property(x => x.Ubicacion).HasMaxLength(50).HasColumnName("Ubicacion").HasColumnType("varchar");
            builder.Property(x => x.Disponibilidad).HasMaxLength(50).HasColumnName("Disponibilidad").HasColumnType("varhcar");
            builder.Property(x => x.Precio).HasColumnName("Precio").HasColumnType("int");
            builder.Property(x => x.Fecha).HasColumnName("Fecha").HasColumnType("varchar");
            builder.Property(x => x.Estado).HasColumnName("Estado").HasColumnType("varchar");
            builder.Property(x => x.UrlImagen).HasMaxLength(500).HasColumnName("UrlImagen").HasColumnType("varchar");
        }
    }
}

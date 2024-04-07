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
    public class ArrendarConfiguration : IEntityTypeConfiguration<Arrendar>
    {
        public void Configure(EntityTypeBuilder<Arrendar> builder)
        {
            builder.HasKey(x => x.IdArrendamiento);

            builder.Property(x => x.IdArrendamiento).HasColumnName("IdArrendamiento");
            builder.Property(x => x.Propiedad).HasColumnName("Propiedad").HasColumnType("varhcar");
            builder.Property(x => x.Estado).HasColumnName("Estado").HasColumnType("varchar");
        }
    }
}

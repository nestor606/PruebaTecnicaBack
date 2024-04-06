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
            builder.HasKey(x => x.IdPropiedad);

            builder.Property(x => x.IdPropiedad).has
        }
    }
}

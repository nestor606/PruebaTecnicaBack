using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Infraestructura.Configuration.Entitty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Configuration.Extension
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Propiedad, PropieadadDomain>();
            CreateMap<PropieadadDomain, Propiedad>();

            CreateMap<Arrendar, ArrendarDomain>();
            CreateMap<ArrendarDomain, Arrendar>();
        }
    }
}

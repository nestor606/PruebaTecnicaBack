using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inmobiliaria.Domain.Util.Mapper
{
    public class AutoMappingProfile : AutoMapper.Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<PropieadadDomain, PropiedadDto>();
            CreateMap<PropiedadDto, PropieadadDomain>();

            CreateMap<PropieadadDomain,CreatePropiedadDto>();
            CreateMap<CreatePropiedadDto, PropieadadDomain>();

            CreateMap<ArrendarDomain, ArrendarDTO>();
            CreateMap<ArrendarDTO, ArrendarDomain>();

            
        }
    }
}

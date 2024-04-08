using AutoMapper;
using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Inmobiliaria.Infraestructura.Configuration.Contexto;
using Inmobiliaria.Infraestructura.Configuration.Entitty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Repository
{
    public class ArrendarRepository : IArrendarRepos
    {
        private readonly ApplicationsContext _Dbcontext;
        private readonly IMapper _Mapper;

        public ArrendarRepository(ApplicationsContext context, IMapper mapper)
        {
            _Dbcontext = context;
            _Mapper = mapper;
        }

        public ArrendarDTO Actualizar(ArrendarDomain arrendar)
        {
            throw new NotImplementedException();
        }

        public ArrendarDTO Create(ArrendarDomain arrendar)
        {
            _Dbcontext.Arrendar.Add(_Mapper.Map<Arrendar>(arrendar));
            _Dbcontext.SaveChanges();
            return _Mapper.Map<ArrendarDTO>(arrendar);
        }

        public List<ArrendarDTO> ObtenerAlquiler(int propiedad)
        {
            var query = @"select * from arrendar a inner join propiedad p on (a.propiedad = p.IdPopiedad)
                            where a.proiedad = :propiedad ";
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.UseCase
{
    public class ArrendarUseCase : IArrendar
    {
        private readonly IArrendarRepos _repos;
        private readonly IPropiedadesRepos _propiedades;
        private readonly IMapper _mapper;
        public ArrendarUseCase(IArrendarRepos arrendar, IMapper mapper, IPropiedadesRepos propiedades)
        {
            _repos = arrendar;
            _mapper = mapper;
            _propiedades = propiedades;

        }
        public ArrendarDTO CrearAlquiler(ArrendarDTO arrendar)
        {

            ArrendarDomain _Arrendar = _mapper.Map<ArrendarDomain>(arrendar);
            var request =  _repos.Create(_Arrendar);
            PropiedadDto propiedadExistente = _propiedades.BuscarporId(_Arrendar.Propiedad);
            propiedadExistente.Disponibilidad = "NO";
            _propiedades.ActualizarPropiedad(_mapper.Map<PropieadadDomain>(propiedadExistente));

            
            return request;
        }
        public List<ArrendarDTO> ObtenerAlquilerporPropiedad(int Propiedad) {

            return _repos.ObtenerAlquiler(Propiedad);
        }
        public ArrendarDTO ActualizarAlquiler(ArrendarDomain arrendar) { 
        
            return _repos.Actualizar(arrendar);
        }
    }
}

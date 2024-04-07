using AutoMapper;
using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Inmobiliaria.Domain.Util.Exceptions;

namespace Inmobiliaria.Domain.UseCase
{
    public class PropiedadesUsecase : Ipropiedades
    {
        private readonly IPropiedadesRepos _repos;
        private readonly IMapper _mapper;

        public PropiedadesUsecase(IPropiedadesRepos propiedadesRepos, IMapper mapper)
        {
             _repos = propiedadesRepos;
            _mapper = mapper;
        }
        public PropiedadDto AgregarPropiedad(PropiedadDto propiedad)
        {
            PropiedadDto Dto = ExisteData(propiedad.Nombre);

            if (Dto != null)
            {
                throw new BusinessRuleExeption("Ya Existe un registro, Favor Verifique la Propiedad a registrar");
            }
            UbicacionDto ubicacionDto = new UbicacionDto();
            foreach (var item in ubicacionDto.ObtenerUbicacion())
            {
                if (propiedad.Ubicacion == item.Nombre)
                {
                    if (item.Nombre == "Cali" || item.Nombre == "Bogota")
                    {
                        if (propiedad.Precio >= 2000000)
                        {
                            break;
                        }
                        else {

                            throw new BusinessRuleExeption($"El precio registrado no corresponde al permitido  para {propiedad.Ubicacion}");
                        }
                    }
                    break;
                }
                
            }
            
            PropieadadDomain _Propiedad = _mapper.Map<PropieadadDomain>(propiedad);
            var request = _repos.Agregar(_Propiedad);
            return request;
        }

        public List<PropiedadDto> GetValorMaxMinPropiedades(int Max, int Min)
        {
            StatusDto statusDto = new StatusDto();
            var request =  _repos.GetValorMaxMin(Max,Min).ToList();
            return request;
        }
        public PropiedadDto ExisteData(string Nombre)
        {
            return _repos.ExistePropiedad(Nombre);
        }

        public PropiedadDto EliminarPropiedad(string Nombre)
        {
            PropiedadDto Dto = ExisteData(Nombre);

            if (Dto == null)
            {
                throw new BusinessRuleExeption("El registro a Eliminar no existe, favor Verificar");
            }
            PropieadadDomain _Propiedad = _mapper.Map<PropieadadDomain>(Dto);
            return _repos.Eliminar(_Propiedad);

        }
    }
}

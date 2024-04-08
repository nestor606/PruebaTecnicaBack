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
        public CreatePropiedadDto AgregarPropiedad(CreatePropiedadDto propiedad)
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
            var request =  _repos.GetValorMaxMin(Max,Min).ToList();
            return request;
        }
        public PropiedadDto ExisteData(string Nombre)
        {
            return _repos.ExistePropiedad(Nombre);
        }

        public string EliminarPropiedad(string Nombre)
        {
            DateTime date = DateTime.Now;
            bool status = false;
            string menssage = "";
            PropiedadDto Dto = ExisteData(Nombre);
            PropieadadDomain _Propiedad = _mapper.Map<PropieadadDomain>(Dto);
            DateTime fechadate = Convert.ToDateTime(Dto.Fecha);
            if (Dto == null)
            {
                throw new BusinessRuleExeption("El registro a Eliminar no existe, favor Verificar");
            }
            if (fechadate.Day >= date.Day && fechadate.Month < date.Month && fechadate.Year >= date.Year)
            {
                if (_repos.Eliminar(_Propiedad) != null)
                    status = true;

            }
            else {

                if (_repos.ActualizarPropiedad(_Propiedad) != null)
                    status =  true;
                
               
            }
            if (status)
            {
                menssage = "Eliminacion Realizada Exitosamente";
            }
            return menssage;

        }
    }
}

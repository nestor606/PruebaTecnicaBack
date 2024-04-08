using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IPropiedadesRepos
    {
        List<PropiedadDto> GetValorMaxMin(int Max, int Min);
        List<PropiedadDto> GetPropiedadDtos();
        PropiedadDto BuscarporId(int id);
        CreatePropiedadDto Agregar(PropieadadDomain propiedad);
        PropiedadDto BuscarporNombre(string Nombre);
        bool Eliminar(PropieadadDomain propiedad);
        PropiedadDto ActualizarPropiedad(PropieadadDomain propieadad);
    }
}

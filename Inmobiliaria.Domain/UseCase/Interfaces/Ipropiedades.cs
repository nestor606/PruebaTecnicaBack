using Inmobiliaria.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.UseCase.Interfaces
{
    public interface Ipropiedades
    {
        List<PropiedadDto> GetValorMaxMinPropiedades(int Max, int Min);
        CreatePropiedadDto AgregarPropiedad(CreatePropiedadDto propiedad);
        String EliminarPropiedad(string Nombre);
        PropiedadDto EditarPropieda(PropiedadDto propiedad);

    }
}
 
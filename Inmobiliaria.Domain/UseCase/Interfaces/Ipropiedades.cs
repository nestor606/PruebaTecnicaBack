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
        List<ListPropiedaValorMaxMinDto> GetValorMaxMinPropiedades();
        Task<PropiedadDto> AgregarPropiedad(PropiedadDto propiedad);


    }
}
 
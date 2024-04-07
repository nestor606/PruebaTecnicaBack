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
        PropiedadDto Agregar(PropieadadDomain propiedad);
        PropiedadDto ExistePropiedad(string Nombre);
        PropiedadDto Eliminar(PropieadadDomain propiedad);
    }
}

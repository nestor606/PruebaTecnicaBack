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
        CreatePropiedadDto Agregar(PropieadadDomain propiedad);
        PropiedadDto ExistePropiedad(string Nombre);
        bool Eliminar(PropieadadDomain propiedad);
        PropiedadDto ActualizarPropiedad(PropieadadDomain propieadad);
    }
}

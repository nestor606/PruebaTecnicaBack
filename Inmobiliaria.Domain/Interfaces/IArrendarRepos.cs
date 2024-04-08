using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.Interfaces
{
    public interface IArrendarRepos
    {
        ArrendarDTO Create(ArrendarDomain arrendar);
        ArrendarDTO Actualizar(ArrendarDomain arrendar);
        List<ArrendarDTO> ObtenerAlquiler(int propiedad);
    }
}

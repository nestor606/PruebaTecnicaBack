using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.Domain
{
    public  class PropieadadDomain
    {
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Disponibilidad { get; set; }
        public int Precio { get; set; }
        public string UrlImagen { get; set; }

    }
}

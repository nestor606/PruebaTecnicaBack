using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Configuration.Entitty
{
    public class Propiedad
    {
        public int IdPropiedad { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Disponibilidad { get; set; }
        public int Precion { get; set; }
        public string UrlImagen { get; set; }
    }
}

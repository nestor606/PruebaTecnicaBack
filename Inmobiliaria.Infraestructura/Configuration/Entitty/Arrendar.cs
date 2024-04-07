using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Configuration.Entitty
{
    public class Arrendar
    {
        public int IdArrendamiento { get; set; }
        public int Propiedad { get; set; }
        public string Estado { get; set; }
    }
}

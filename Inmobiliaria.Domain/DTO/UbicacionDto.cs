using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.DTO
{
    public class UbicacionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public UbicacionDto[] ObtenerUbicacion ()
        {
            UbicacionDto[] Zona = new UbicacionDto[4];
            Zona[0] = new UbicacionDto { Id = 1, Nombre = "Bogota" };
            Zona[1] = new UbicacionDto { Id = 2, Nombre = "Cali" };
            Zona[2] = new UbicacionDto { Id = 3, Nombre = "Cartagena" };
            Zona[3] = new UbicacionDto { Id = 4, Nombre = "Medellin" };

            return Zona;
        }
    }
    


}

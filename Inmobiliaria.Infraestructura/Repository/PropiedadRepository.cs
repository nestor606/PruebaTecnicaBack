using AutoMapper;
using Inmobiliaria.Domain.Domain;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Infraestructura.Configuration.Contexto;
using Inmobiliaria.Infraestructura.Configuration.Entitty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Repository
{
    public class PropiedadRepository : IPropiedadesRepos
    {
        private readonly ApplicationsContext _DbContext;
        private readonly IMapper _Mapper;

        public PropiedadRepository(ApplicationsContext Conexion, IMapper mapper)
        {
            _DbContext = Conexion;
            _Mapper = mapper;
        }
        public PropiedadDto Agregar(PropieadadDomain propiedad)
        {
             var propiedadEntity = _DbContext.Propiedad.Add(_Mapper.Map<Propiedad>(propiedad));
            _DbContext.SaveChanges();
            return _Mapper.Map<PropiedadDto>(propiedad);
            
        }

        public PropiedadDto Eliminar(PropieadadDomain propiedad)
        {
            throw new NotImplementedException();
        }

        public PropiedadDto ExistePropiedad(string Nombre)
        {
            var Existe = _DbContext.Propiedad.Where(x => x.Nombre == Nombre).FirstOrDefault();
            return _Mapper.Map<PropiedadDto>(Existe);
        }

        public List<PropiedadDto> GetValorMaxMin(int Max, int Min)
        {
            IQueryable<PropiedadDto> query = (from p in _DbContext.Propiedad 
                                              where p.Disponibilidad == "SI" && p.Precio >= Min && p.Precio <= Max 
                                              select new PropiedadDto { 
                                                    Nombre = p.Nombre,
                                                    Precio = p.Precio,
                                                    Disponibilidad = p.Disponibilidad,
                                                    Ubicacion = p.Ubicacion,
                                                    UrlImagen = p.UrlImagen
                                             });
            return query.ToList();
        }
    }
}

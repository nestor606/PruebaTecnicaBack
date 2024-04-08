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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public PropiedadDto ActualizarPropiedad(PropieadadDomain propiedad)
        {
            
            _DbContext.Propiedad.Update(_Mapper.Map<Propiedad>(propiedad));
            _DbContext.SaveChanges();

            return _Mapper.Map<PropiedadDto>(propiedad);
        }

        public CreatePropiedadDto Agregar(PropieadadDomain propiedad)
        {
             var propiedadEntity = _DbContext.Propiedad.Add(_Mapper.Map<Propiedad>(propiedad));
            _DbContext.SaveChanges();
            return _Mapper.Map<CreatePropiedadDto>(propiedad);
            
        }

        public bool Eliminar(PropieadadDomain propiedad)
        {
            _DbContext.Remove(_Mapper.Map<Propiedad>(propiedad));
            _DbContext.SaveChanges();
            return true;
        }

        public PropiedadDto BuscarporNombre(string Nombre)
        {
            PropiedadDto? Query = (from p in _DbContext.Propiedad
                                  where p.Nombre == Nombre && p.Disponibilidad == "SI" && p.Estado == "1" 
                                  select new PropiedadDto
                                  {
                                      IdPopiedad = p.IdPopiedad,
                                      Nombre = p.Nombre,
                                      Disponibilidad = p.Disponibilidad,
                                      Fecha = p.Fecha,
                                      Precio = p.Precio,
                                      Ubicacion = p.Ubicacion,
                                      UrlImagen = p.UrlImagen
                                  }).AsNoTracking().FirstOrDefault();
            return Query;
        }

        public List<PropiedadDto> GetValorMaxMin(int Max, int Min)
        {
            IQueryable<PropiedadDto> query = (from p in _DbContext.Propiedad 
                                              where p.Disponibilidad == "SI" && p.Estado == "1" && p.Precio >= Min && p.Precio <= Max 
                                              select new PropiedadDto { 
                                                    Nombre = p.Nombre,
                                                    Precio = p.Precio,
                                                    Disponibilidad = p.Disponibilidad,
                                                    Ubicacion = p.Ubicacion,
                                                    UrlImagen = p.UrlImagen
                                             });
            return query.ToList();
        }

        public List<PropiedadDto> GetPropiedadDtos()
        {
            IQueryable<PropiedadDto> query = (from p in _DbContext.Propiedad
                                              where p.Disponibilidad == "SI" && p.Estado == "1"
                                              select new PropiedadDto
                                              {
                                                  IdPopiedad = p.IdPopiedad,
                                                  Nombre = p.Nombre,
                                                  Disponibilidad = p.Disponibilidad,
                                                  Fecha = p.Fecha,
                                                  Precio = p.Precio,
                                                  Ubicacion = p.Ubicacion,
                                                  UrlImagen = p.UrlImagen

                                              }).AsNoTracking();
            return query.ToList();
        }

        public PropiedadDto BuscarporId(int id)
        {
            PropiedadDto? query = (from p in _DbContext.Propiedad
                                              where p.IdPopiedad == id && p.Estado == "1" && p.Disponibilidad == "SI" 
                                              select new PropiedadDto
                                              {
                                                  IdPopiedad = p.IdPopiedad,
                                                  Nombre = p.Nombre,
                                                  Disponibilidad = p.Disponibilidad,
                                                  Fecha = p.Fecha,
                                                  Precio = p.Precio,
                                                  Ubicacion = p.Ubicacion,
                                                  UrlImagen = p.UrlImagen,
                                                  Estado = p.Estado

                                              }).AsNoTracking().FirstOrDefault();
            return query;
        }
    }
}

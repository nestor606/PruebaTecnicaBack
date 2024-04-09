using AutoMapper;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.UseCase;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Inmobiliaria.Domain.Util.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Inmobiliaria.Test.UseCaseTest
{
    [TestClass]
    public class PropiedadTest
    {
        [TestMethod]
        public void CuandoInsertoPropiedad() {

            //Arrange
            var propiedadDto = new PropiedadDto()
            {
                IdPopiedad = 2,
                Nombre = "Conjunto Jade",
                Precio = 2200000,
                Disponibilidad = "SI",
                Estado = "0",
                Fecha = "03/04/2024",
                Ubicacion = "Cali",
                UrlImagen = "SFSAFAFIUFSUFIDUFDISUGIDDVNMJIVNJUIVHUUGVFOVFVNUIGHUFDHVFDNVNFDUVBHFDUHUIDYHGUIFDYGUIDYGIGUGDGYUYFD"
            };
            CreatePropiedadDto propiedad = new CreatePropiedadDto()
            {

                Nombre = "Conjunto Jade",
                Precio = 2200000,
                Disponibilidad = "SI",
                Fecha = "03/04/2024",
                Ubicacion = "Cali",
                UrlImagen = "SFSAFAFIUFSUFIDUFDISUGIDDVNMJIVNJUIVHUUGVFOVFVNUIGHUFDHVFDNVNFDUVBHFDUHUIDYHGUIFDYGUIDYGIGUGDGYUYFD"
            };
            UbicacionDto ubicacionDto = new UbicacionDto();
            foreach (var item in ubicacionDto.ObtenerUbicacion())
            {
                if (propiedadDto.Ubicacion == item.Nombre)
                {
                    if (item.Nombre == "Cali" || item.Nombre == "Bogota")
                    {
                        if (propiedadDto.Precio >= 2000000)
                        {
                            break;
                        }
                    }
                    break;
                }

            }
            var IMapper = Substitute.For<IMapper>();
            var _propiedadRepository = Substitute.For<IPropiedadesRepos>();

            _propiedadRepository.BuscarporNombre(propiedadDto.Nombre).Returns(propiedadDto);

            Ipropiedades _propiedadesUseCase = new PropiedadesUsecase(_propiedadRepository, IMapper);

            //aCT
            var result = _propiedadesUseCase.AgregarPropiedad(propiedad);

            //Asset
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CuandoObtengovalorMaxMin() {

            //Arrenge

            int Min = 1000000;
            int Max = 2500000;
 
            List<PropiedadDto> propiedadDto = new List<PropiedadDto>()
            {
                new PropiedadDto(){

                    IdPopiedad = 2,
                    Nombre = "Conjunto Jade",
                    Precio = 2200000,
                    Disponibilidad = "SI",
                    Estado = "0",
                    Fecha = "03/04/2024",
                    Ubicacion = "Cali",
                    UrlImagen = "SFSAFAFIUFSUFIDUFDISUGIDDVNMJIVNJUIVHUUGVFOVFVNUIGHUFDHVFDNVNFDUVBHFDUHUIDYHGUIFDYGUIDYGIGUGDGYUYFD"
                }
                
            };
            var _propiedadRepository = Substitute.For<IPropiedadesRepos>();

            Ipropiedades _propiedadesUseCase = new PropiedadesUsecase(_propiedadRepository, null);

            //Act
            var result = _propiedadesUseCase.GetValorMaxMinPropiedades(Max, Min);

            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CuandoEliminoPropiedad() { 
        

        }

    }
}

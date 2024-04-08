using Inmobiliaria.Api.Resource;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inmobiliaria.Api.Controllers
{
    //[Authorize]
    [ApiController]
    public class PropiedadController : Controller
    {
        #region Atributos
        private readonly ILogger<PropiedadController> _logger;
        private readonly Ipropiedades _Propiedad;
        #endregion

        #region Costructor
        public PropiedadController(ILogger<PropiedadController> logger, Ipropiedades PropiedadUsecase)
        {
            _logger = logger;
            _Propiedad = PropiedadUsecase;

        }
        #endregion

        [HttpPost]
        [Route("CreatePropiedad")]
        public ResponseDto CreatePropiedad(CreatePropiedadDto DTO)
        {
            _logger.LogInformation("INICIANDO LA CREACION DE LAS PROPIEDAD ");
            var Response = new ResponseDto()
            {
                Status = ResponseBuilder.CreateSuccssReponse(HttpStatusCode.OK),
                Data = _Propiedad.AgregarPropiedad(DTO)
            };
            _logger.LogInformation("Finalizando Registro");
            return Response;
        }
        [HttpGet]
        [Route("ListarValorMaxMin")]
        public ResponseDto ListarValorMaxMin(int Min, int Max) {

            _logger.LogInformation("INICIANDO LA CONSULTA DE VALORES MAXIMO Y MINIMO");
            var response = new ResponseDto()
            {

                Status = ResponseBuilder.CreateSuccssReponse(HttpStatusCode.OK),
                Data = _Propiedad.GetValorMaxMinPropiedades(Max, Min)

            };
            _logger.LogInformation("Finalizando Consulta");

            return response;
        }
        [HttpDelete]
        [Route("EliminarPropiedad")]
        public ResponseDto EliminarPropiedad(string Nombre )
        {

            _logger.LogInformation("INICIANDO LA ELIMINACION DE LA PROPIEDAD");
            var response = new ResponseDto()
            {

                Status = ResponseBuilder.CreateSuccssReponse(HttpStatusCode.OK),
                Data = _Propiedad.EliminarPropiedad(Nombre)
            };
            _logger.LogInformation("Finalizando Eliminacion");

            return response;
        }


    }
}

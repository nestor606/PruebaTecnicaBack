using Inmobiliaria.Api.Resource;
using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Inmobiliaria.Infraestructura.Configuration.Entitty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inmobiliaria.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class ArrendarController : Controller
    {
        private readonly ILogger<ArrendarController> _logger;
        private readonly IArrendar _arrendar;

        public ArrendarController(ILogger<ArrendarController> logger, IArrendar arrendar)
        {
            _logger = logger;
            _arrendar = arrendar;
                
        }

        [HttpPost]
        [Route("CreacionArrendamiento")]
        public ResponseDto CreacionArrendamiento(ArrendarDTO arrendarDTO) {

            _logger.LogInformation("INICIANDO LA CREACION DEl ALQUILER ");
            var Response = new ResponseDto()
            {
                Status = ResponseBuilder.CreateSuccssReponse(HttpStatusCode.OK),
                Data = _arrendar.CrearAlquiler(arrendarDTO)
            };
            _logger.LogInformation("Finalizando Registro");
            return Response;
        }

    }
}

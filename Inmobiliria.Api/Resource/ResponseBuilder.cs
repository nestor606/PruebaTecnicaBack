using Inmobiliaria.Domain.DTO;
using Inmobiliaria.Domain.Util.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.WebSockets;

namespace Inmobiliaria.Api.Resource
{
    public class ResponseBuilder
    {
        public static StatusDto CreateSuccssReponse(HttpStatusCode code) {

            return new StatusDto
            {
                Code = code,
                Description = code.ToString(),
                
            };
        }
        public static StatusDto CreateErrorrResponse(HttpStatusCode code, string message) {

            return new StatusDto
            {
                Code = code,
                Description = code.ToString(),
                Message = message
            };
        }
        public static StatusDto CreateErrorResponse(Exception ex) {

            switch (ex) 
            { 
                case var _ when ex is ArgumentNullException:
                case var _ when ex is ValidationException:
                    return CreateErrorrResponse(HttpStatusCode.BadRequest, $"{ex}");
                case var _ when ex is BusinessRuleExeption:
                    return CreateErrorrResponse(HttpStatusCode.BadRequest, ex.Message);
                case var _ when ex is HttpListenerException:
                case var _ when ex is Exception:
                    return CreateErrorrResponse(HttpStatusCode.InternalServerError, $"{ex}");
                case var _ when ex is null:
                    return CreateErrorrResponse(HttpStatusCode.InternalServerError, $"{ex}");
                default:
                    return CreateErrorrResponse(HttpStatusCode.InternalServerError, $"{ex}");

            }
        }
    }
}

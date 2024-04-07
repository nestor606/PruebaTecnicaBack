using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.DTO
{
    public class StatusDto
    {
        public HttpStatusCode Code { get; set; }
        public string? Description { get; set; }
        public string? Message { get; set; }
    }
}

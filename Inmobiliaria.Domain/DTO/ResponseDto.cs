using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Domain.DTO
{
    public class ResponseDto
    {
        public StatusDto? Status { get; set; }
        public object? Data { get; set; }
        
    }
}

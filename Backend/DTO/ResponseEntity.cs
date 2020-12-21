using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class ResponseEntity<T>
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public T Response { get; set; }

    }
}

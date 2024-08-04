using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Framework.Response.Base
{
    public class ApiResponse<T>
    {
        public int statusCode { get; set; }
        public object meta { get; set; }
        public bool succeeded { get; set; }
        public string message { get; set; }
        public object errors { get; set; }
        public T data { get; set; }
    }
}

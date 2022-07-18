using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public bool Error { get; set; } = false;
        public string Message { get; set; } = "Operation excecuted successfully";
    }
}

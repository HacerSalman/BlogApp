using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Response
{
    public interface IResponseDatat<out T> 
    {
        T Data { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public ResponseStatus Status { get; }
    }
}

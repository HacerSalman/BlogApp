using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Response
{
    public class ResponseData<T> : IResponseDatat<T>
    {
        public ResponseData( T data)
        {
            Data = data;
        }
        public ResponseData( string message, T data)
        {
            Message = message;
            Data = data;
        }
        public ResponseData( string message, T data, Exception exception)
        {
            Message = message;
            Data = data;
            Exception = exception;
        }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}

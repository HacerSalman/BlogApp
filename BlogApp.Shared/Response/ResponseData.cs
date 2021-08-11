using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Response
{
    public class ResponseData<T> : IResponseDatat<T>
    {
        public ResponseData(ResponseStatus status, T data)
        {
            Data = data;
            Status = status;
        }
        public ResponseData(ResponseStatus status,string message, T data)
        {
            Message = message;
            Data = data;
            Status = status;
        }
        public ResponseData(ResponseStatus status, string message, T data, Exception exception)
        {
            Message = message;
            Data = data;
            Exception = exception;
            Status = status;
        }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
        public ResponseStatus Status { get; }
    }
}

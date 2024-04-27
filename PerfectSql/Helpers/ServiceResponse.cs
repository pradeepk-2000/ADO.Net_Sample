using System.Net;

namespace PerfectSql.Helpers
{
    public class ServiceResponse<T> : Response where T : class
    {
        public T? Result { get; set; }
    }
    public class Response
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}

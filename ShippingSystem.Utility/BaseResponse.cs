using System.Net;

namespace ShippingSystem.Utility
{
    public class BaseResponse
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public object Result { get; set; }
    }
}

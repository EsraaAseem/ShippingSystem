

namespace ShippingSystem.Service.Exceptions.RequestExceptions
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException(string message) : base(message) { }
    }
}

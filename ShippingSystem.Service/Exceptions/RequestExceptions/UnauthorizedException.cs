
namespace ShippingSystem.Service.Exceptions.RequestExceptions
{
    public class UnauthorizedException: Exception
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}

namespace ShippingSystem.Service.Exceptions.RequestExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

    }
}

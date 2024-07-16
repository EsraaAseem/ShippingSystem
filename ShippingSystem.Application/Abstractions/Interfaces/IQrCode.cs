

namespace ShippingSystem.Application.Abstractions.Interfaces
{
    public interface IQrCode
    {
        string GenerateBarCode(string barCode);
    }
}

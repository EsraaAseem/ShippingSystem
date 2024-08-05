using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface ICityQueryService
    {
        IQueryable<City> GetCities();
        Task<City> GetCityAsync(string cityName);
    }
}

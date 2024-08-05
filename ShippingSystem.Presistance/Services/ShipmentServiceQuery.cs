using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using ShippingSystem.Presistance.Specifications;

namespace ShippingSystem.Presistance.Services
{
    public class ShipmentServiceQuery : IShipmentServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public ShipmentServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Shipment>> GetClientShipmentsShipped(string clientId)
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ClientId == clientId &&
        ship.Shipping.IsShipped == true && ship.GeneralStatus != GeneralShipmentStatus.InvoiceCreated)).ToListAsync();
        }
        public async Task<List<Shipment>> GetClientShipmentsShipping(string clientId)
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ClientId == clientId &&
        ship.Shipping.IsShipped == false)).ToListAsync();
        }
        public async Task<List<Shipment>> GetClientShipmentsRequests(string clientId)
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ClientId == clientId &&
          ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.UnConfirmed)).ToListAsync();
        
        }
        public async Task<List<Shipment>> GetClientShipmentsRejected(string clientId)
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ClientId == clientId &&
          ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.Returned)).ToListAsync();

        }
        public async Task<List<Shipment>> GetClientShipmentsRejectedWithPaid(string clientId)
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ClientId == clientId &&
          ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.ReturnedWithPaid)).ToListAsync();

        }
        public double GetClientIndebtes(string clientId)
        {
            return  _context.Shipments.Where(s => s.NetAccount() > 0).Sum(s => s.NetAccount());
        }
        public double GetClientIndebtness(string clientId)
        {
            return Math.Abs( _context.Shipments.Where(s => s.NetAccount() < 0).Sum(s => s.NetAccount()));
        }

        public async Task<List<Shipment>> GetShipmentsShipped()
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship =>
        ship.Shipping.IsShipped == true && ship.GeneralStatus != GeneralShipmentStatus.InvoiceCreated)).ToListAsync();
        }
        public async Task<List<Shipment>> GetShipmentsShipping()
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.Shipping.IsShipped == false)).ToListAsync();
        }
        public async Task<List<Shipment>> GetShipmentsRequests()
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.UnConfirmed)).ToListAsync();

        }
        public async Task<List<Shipment>> GetShipmentsRejected()
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.Returned)).ToListAsync();
        }
        public async Task<List<Shipment>> GetShipmentsRejectedWithPaid()
        {
            return await ApplySpecification(new ShipmentSpecifaction(ship => ship.ShippmentStatus.ShipmentStatusName ==
            ShipmentStatuses.ReturnedWithPaid)).ToListAsync();

        }
        private IQueryable<Shipment> ApplySpecification(Specification<Shipment> specification)
        {
            return SpecificationEvaluator.GetQuery(_context.Set<Shipment>(), specification);
        }
    }
}



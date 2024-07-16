
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Helper;
using System.Text.Json.Serialization;

namespace ShippingSystem.Domain.Models
{
    public class Shipment:AggregateRoot
    {
        private readonly List<Product> _products = new();

       /* public Shipment(Guid id, List<Product> products, string trackingNumber, Guid? backupId, Guid cityId,
            Reciver reciver,int shipmentTypeId, DateTime? movedDate, int shipmentStatusId,PaymentStatus paymentStatus) : base(id)
        {
            _products = products;
            TrackingNumber = trackingNumber;
            BackupId = backupId;
            CityId = cityId;
            Reciver = reciver;
            ShipmentTypeId = shipmentTypeId;
            MovedDate = movedDate;
            ShipmentStatusId = shipmentStatusId;
            PaymentStatus = paymentStatus;
        }
        */
        public Shipment(Guid id) : base(id)
        {
        }

        public string TrackingNumber { get; set; }
        public Guid? BackupId { get; set; }
        public Beackup? BackUp { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string? ClientId { get; private set; }
        public Client Client { get; private set; }
        public IReadOnlyCollection<Product> Products => _products;
        public Reciver Reciver { get; set; }
        public int ShipmentTypeId { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public DateTime? MovedDate { get; set; }
        public DateTime? ProccedDate { get; set; }
        public Guid? ShipmentStatusId { get; set; }
        public ShipmentStatus ShippmentStatus { get; set; }
        public Guid? ShippingId { get; set; }
        public Shipping? Shipping { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public GeneralShipmentStatus GeneralStatus { get; private set; } = GeneralShipmentStatus.Unknown;
        public double TotalRealPrice { get;private set; }
        public string? QrCodeUrl { get; private set; }
        public double TotalProductsWight => Products.Sum(product => product.TotalWeight);
        public double TotalProductsPrice => Products.Sum(product => product.TotalPrice);
        public double TotalPrice => TotalProductsPrice + ShippingPrice();
        public double NetAccount => PaymentStatus == PaymentStatus.Pending ? TotalProductsPrice - ShippingPrice() : - ShippingPrice();
        public double ShippingPrice()
        {
            double price = 0;
            if (ShippmentStatus.ShipmentStatusName == "Returned")
                price = City.ReturnShippingCost+ShipmentType.ExtreShippingCost;
                else price = City.ShippingCost+ShipmentType.ExtreShippingCost;
                if (PaymentStatus == PaymentStatus.Pending)
                    price += ((TotalProductsWight - 1) * City.ExcessShippingCost);

            return price;
        }
        /*  public Shipment CreateShipment(Guid id, List<Product> products, string trackingNumber, Guid? backupId,
              Guid cityId,Reciver reciver, int shipmentTypeId, DateTime? movedDate, int shipmentStatusId,PaymentStatus paymentStatus)
          {

             return new Shipment(id, products, trackingNumber, backupId, cityId, reciver, shipmentTypeId, 
                 movedDate, shipmentStatusId, paymentStatus);
           }*/
        public static string BarCodeShipment(string trackNumber)
        {
            return string.Format(" Tracking Number : {0}\n", trackNumber);
        }
        public static Shipment CreateShipment(Guid id, List<Product> products, string trackingNumber, Guid? backupId,
       Guid cityId,string? clientId, Reciver reciver, int shipmentTypeId, DateTime? movedDate, 
       Guid shipmentStatusId, PaymentStatus paymentStatus,string?qrCode)
        {
            var shipment = new Shipment(id);
            shipment.TrackingNumber = trackingNumber;
            shipment.BackupId = backupId;
            shipment.CityId = cityId;
            shipment.Reciver = reciver;
            shipment.ShipmentTypeId = shipmentTypeId;
            shipment.MovedDate = movedDate;
            shipment.ShipmentStatusId = shipmentStatusId;
            shipment.PaymentStatus = paymentStatus;
            shipment.ClientId = clientId;
            shipment.QrCodeUrl= qrCode;
            shipment._products.AddRange(products);
            return shipment;
        }
    }
}

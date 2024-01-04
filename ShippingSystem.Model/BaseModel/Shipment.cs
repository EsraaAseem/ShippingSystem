using ShippingSystem.Model.HelperModel;
using System.Text.Json.Serialization;

namespace ShippingSystem.Model.BaseModel
{
    public class Shipment
    {
      

        public int ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public Guid? BackupId { get; set; }
        public BackUp BackUp { get; set; }
       // public string ClientId { get; set; }
      //  public Client Client { get; set; }
        public List<Product> Products { get; set; }
        public Reciver Reciver { get; set; }
       public int? ShippingId { get; set; }
       public Shipping? Shipping { get; set; }
         public int? AreaId { get; set; }
         public Area Area { get; set; }
        public DateTime? MovedDate { get; set; }
        public DateTime? ProccedDate { get; set; }
        public int ShipmentStatusId { get; set; }
        public ShipmentStatus ShippingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public double TotalWight { get; set; }  
        [JsonIgnore]
        public double TotalProductsPrice { get; set; }
        [JsonIgnore]
        public double ShippingPrice { get; set; }
        public double TotalPrice { get; set; }
        public double NetAccount { get; set; }
        public void CalculatePrices(Area?area=null,ShipmentStatus?shipmentStatus=null)
        {
            TotalProductsPrice = Products.Sum(p => p.ProductPrice * p.Amount);
            TotalWight = Products?.Sum(p => p.ProductWeight * p.Amount) ?? 0;
            
            if(area != null)
            {
                if (shipmentStatus?.ShipmentStatusName == "Completed")
                {
                    ShippingPrice = area.ShippingPrice + ((TotalWight - 1) * area.ExcessShippingPrice);
                }
                else
                    ShippingPrice = area.ReturnShippingPrice;
            }
            TotalPrice = TotalProductsPrice + ShippingPrice;
            NetAccount = TotalProductsPrice - ShippingPrice;
        }
    }
}

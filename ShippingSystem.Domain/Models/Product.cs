

namespace ShippingSystem.Domain.Models
{
    public class Product
    {
        private Product(string productName, int amount, double productPrice, double productWeight,int recivedAmount)
        {
            ProductName = productName;
            Amount = amount;
            ProductPrice = productPrice;
            ProductWeight = productWeight;
            RecivedAmount = recivedAmount;
        }

        public string ProductName { get;private set; }
        public int Amount { get; private set; } = 1;
        public int RecivedAmount { get; private set; } = 1;

        //if paymentstatus is Pending
        public double ProductPrice { get;private set; }
        public double ProductWeight { get; private  set; }
        public double TotalRecivedPrice => ProductPrice * RecivedAmount;
        public double TotalRecivedWeight => ProductWeight * RecivedAmount;
        public int NotRecivedAmount => Amount-RecivedAmount;
        public double TotalNotRecivedPrice => ProductPrice * NotRecivedAmount;
        public double TotalNotRecivedWeight => ProductWeight * NotRecivedAmount;
        public static Product CreateProduct(string productName, int amount, double productPrice, double productWeight) 
        {
            return new(productName, amount, productPrice, productWeight,amount);
        }
        public void UpdateRecivedAmount(int amount)
        {
            RecivedAmount = amount;    
        }
    }
}

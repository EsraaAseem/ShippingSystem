

namespace ShippingSystem.Domain.Models
{
    public class Product
    {
        private Product(string productName, int amount, double productPrice, double productWeight)
        {
            ProductName = productName;
            Amount = amount;
            ProductPrice = productPrice;
            ProductWeight = productWeight;
        }

        public string ProductName { get;private set; }
        public int Amount { get; private set; } = 1;
        //if paymentstatus is Pending
        public double ProductPrice { get;private set; }
        public double ProductWeight { get; private  set; }
        public double TotalPrice => ProductPrice * Amount;
        public double TotalWeight => ProductWeight * Amount;
        public static Product CreateProduct(string productName, int amount, double productPrice, double productWeight) 
        {
            return new(productName, amount, productPrice, productWeight);
        }
    }
}

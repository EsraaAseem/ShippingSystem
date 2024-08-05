
namespace ShippingSystem.Domain.Share
{
    public class SmtpSettings
    {
        public string Sender { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}

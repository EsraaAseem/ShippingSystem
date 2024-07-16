using Microsoft.EntityFrameworkCore;


namespace ShippingSystem.Domain.Models
{
    [Owned]
  
        public class RefreshToken
        {
        public RefreshToken(string refToken, DateTime createdOn, DateTime expiresOn)
        {
            RefToken = refToken;
            CreatedOn = createdOn;
            ExpiresOn = expiresOn;
            
        }

        public string RefToken { get; private set; }
            public DateTime ExpiresOn { get; private set; }
            public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
            public DateTime CreatedOn { get; private set; }
            public bool IsActive => !IsExpired;
        internal static RefreshToken CreateRefToken(string refToken,DateTime createOn,DateTime expirOn)
        {
            return new RefreshToken(refToken, createOn, expirOn);
        }
        }
    
}

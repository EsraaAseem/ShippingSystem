using ShippingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.ShareResponse
{
    public class NotifactionResponse
    {
        public string? NotifactionImage { get; private set; }
        public string? NotifactionName { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public NotificationType Type { get; private set; }
        public bool? IsRead { get; set; }
        public DateTime NotificationTime { get; private set; }
    }
}

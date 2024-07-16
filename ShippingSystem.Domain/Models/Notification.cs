

using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Helper;
using System.Security.Principal;

namespace ShippingSystem.Domain.Models
{
    public class Notification:Entity
    {
        private Notification(Guid id,string? reciverId,string notifName,
            string? notifImg,string? title,
            string?description,NotificationType type,
            bool?isRead,DateTime notifTime) : base(id)
        {
            ReciverId= reciverId;
            NotifactionName= notifName;
            NotifactionImage= notifImg;
            Title= title;
            Description= description;
            Type= type;
            IsRead= isRead;
            NotificationTime= notifTime;
        }

        public string? ReciverId { get; private set; }
        public string? NotifactionImage { get; private set; }
        public string? NotifactionName { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public NotificationType Type { get; private set; }
        public bool? IsRead { get; set; }
        public DateTime NotificationTime { get; private set; }
        public static void CreateNotifaction(Guid id, string? reciverId, string notifName,
            string? notifImg, string? title,
            string? description, NotificationType type,
            bool? isRead, DateTime notifTime)
        {
            new Notification(id, reciverId, notifName, notifImg, title, description, type, isRead, notifTime);
        }
    }
}

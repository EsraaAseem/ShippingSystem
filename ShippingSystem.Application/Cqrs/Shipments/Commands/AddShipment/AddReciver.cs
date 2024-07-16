using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment;
  public record AddReciver(string name, string city, string streetAddress, string email, string phone);
 

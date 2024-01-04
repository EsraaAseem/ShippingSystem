﻿using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository
{
    public interface IShippingRepository :IRepository<Shipping>
    {
        Task<Shipping> UpdateDeliveryShipmentsAsync(int Id, ShippingUpdateDto DeliveryShipmentsUpdate);

    }
}

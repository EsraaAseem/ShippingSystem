﻿using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System.Numerics;
using System.Xml.Linq;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    internal class AddShipmentCommandHandler : ICommandHandler<AddShipmentCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddShipmentCommandHandler> _localization;
        private readonly IQrCode _qrCodeSeervice;

        public AddShipmentCommandHandler(IUnitOfWork unitOfWork, 
            IStringLocalizer<AddShipmentCommandHandler> localization,IQrCode qrCode)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _qrCodeSeervice = qrCode;
        }
       
        public async Task<BaseResponse> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            var products=new List<Product>();
            var reciver = new Reciver(request.reciver.name, request.reciver.city, request.reciver.streetAddress,
                request.reciver.email, request.reciver.phone);
            string trackingNumber = new string(Guid.NewGuid().ToString().Take(6).ToArray());
            var data = Shipment.BarCodeShipment(trackingNumber);
            var qrCodeUrl = _qrCodeSeervice.GenerateBarCode(data);
             foreach(var product in request.products)
             {
                var productExist = products.Exists(p => p.ProductName == product.productName);
                if (productExist) return await BaseResponse.BadRequestResponsAsync(_localization["ProductAlreadyExist"].Value);
                products.Add(Product.CreateProduct(product.productName, product.amount, product.productPrice, product.productWeight));
             }
            var shipment = Shipment.CreateShipment(Guid.NewGuid(), products,trackingNumber, 
                request.backupId, request.cityId,request.clientId,
                reciver, request.shipmentTypeId, request.movedDate, request.shipmentStatusId,request.paymentStatus,qrCodeUrl);
            await _unitOfWork.ShipmentRepository.Add(shipment);
            await _unitOfWork.SaveChangesAsync();

            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateShipmentSuccess"].Value);
        }
    }
}

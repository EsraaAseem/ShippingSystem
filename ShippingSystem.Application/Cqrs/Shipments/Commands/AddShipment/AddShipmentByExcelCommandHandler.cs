using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    internal class AddShipmentByExcelCommandHandler : ICommandHandler<AddShipmentByExcelCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddShipmentCommandHandler> _localization;
        private readonly IQrCode _qrCodeSeervice;

        public AddShipmentByExcelCommandHandler(IUnitOfWork unitOfWork, 
            IStringLocalizer<AddShipmentCommandHandler> localization,IQrCode qrCode)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _qrCodeSeervice = qrCode;
        }
       
        public async Task<BaseResponse> Handle(AddShipmentByExcelCommand request, CancellationToken cancellationToken)
        {
            using (var stream = new MemoryStream())
            {
                await request.file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var products = new List<Product>();
                        string trackingNumber = new string(Guid.NewGuid().ToString().Take(6).ToArray());
                        var data = Shipment.BarCodeShipment(trackingNumber);
                        var qrCodeUrl = _qrCodeSeervice.GenerateBarCode(data);
                        string clientId = _unitOfWork.ShipmentRepository.GetClientIdAsync( worksheet.Cells[row, 1].Value?.ToString());
                        Guid cityId = _unitOfWork.ShipmentRepository.GetCity( worksheet.Cells[row, 2].Value?.ToString());
                       PaymentStatus paymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), worksheet.Cells[row, 3].Value?.ToString());
                        int shipmentTypeId = _unitOfWork.ShipmentRepository.GetShipmentTypeId( worksheet.Cells[row, 4].Value?.ToString());
                        DateTime MoveData = DateTime.Parse(worksheet.Cells[row, 5].Value?.ToString());
                        Guid shipmentStatusId = _unitOfWork.ShipmentRepository.GetShipmentStausId();
                        //  reciver(name - city - streetAddress - email - phone) -
                        string reciverName = worksheet.Cells[row, 6].Value?.ToString();
                        string reciverCity = worksheet.Cells[row, 7].Value?.ToString();
                        string reciverAddress = worksheet.Cells[row, 8].Value?.ToString();
                        string reciverEmail = worksheet.Cells[row, 9].Value?.ToString();
                        string reciverPhone = worksheet.Cells[row, 10].Value?.ToString();

                        var reciver = new Reciver(reciverName, reciverCity, reciverAddress, reciverEmail, reciverPhone);
                        for (int col = 11; col <= worksheet.Dimension.End.Column; col += 4)
                        {
                            string productName = worksheet.Cells[row, col].Value.ToString();
                            int amount = int.Parse(worksheet.Cells[row, col + 1].Value.ToString());
                            double productPrice = double.Parse(worksheet.Cells[row, col + 2].Value.ToString());
                            double productWeight = double.Parse(worksheet.Cells[row, col + 3].Value.ToString());
                            products.Add(Product.CreateProduct(productName,amount,productPrice,productWeight));
                            
                        }
                        var shipment = Shipment.CreateShipment(Guid.NewGuid(), products, trackingNumber, null, cityId, clientId,
                            reciver,shipmentTypeId, MoveData,shipmentStatusId,paymentStatus,qrCodeUrl);
                        await _unitOfWork.ShipmentRepository.Add(shipment);
                    }

                
                }
                await _unitOfWork.SaveChangesAsync();

            }
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateShipmentSuccess"].Value);
        }
    }
}


using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using ShippingSystem.Application.Abstractions.Interfaces;

namespace ShippingSystem.Infrastructure.Services.BarCode
{
    public class QrCodes : IQrCode
    {
        public string GenerateBarCode(string data)
        {

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                return  ConvertBitmapToBase64(qrCodeImage);
            }
        }
        private static string ConvertBitmapToBase64(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                var url = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(imageBytes));
                return url ;
            }
        }

    }
}

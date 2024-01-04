using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Utility;

namespace ShippingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceCreateDto model)
        {
            var shipments = await _unitOfWork.Shipment.GetAllAsync(x => x.BackUp.ClientId == model.ClientId);
            var invoice = _mapper.Map<Invoice>(model);
            foreach(var shipment in shipments)
            {
                if (shipment.NetAccount < 0)
                    invoice.CompanyMoney += Math.Abs(shipment.NetAccount);
                else
                    invoice.ClientMoney += shipment.NetAccount;
            }
            invoice.TotalNetAccount = invoice.ClientMoney - invoice.CompanyMoney;
            var result = await _unitOfWork.Invoice.AddAsync(invoice);
            _unitOfWork.SaveAsync();
            _response.Result = result;

            return Ok(_response);
        }

    }
}

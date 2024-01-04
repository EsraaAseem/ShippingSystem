using AutoMapper;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;

namespace ShippingSystem.DataAccess.Helper.AutoMapper
{
    public class autoMapping:Profile
    {
        public autoMapping()
        {

            //Client

            CreateMap<RegisterDto,ClientCreateDto>().ReverseMap();
            CreateMap<Client,RegisterDto>().ReverseMap();
            CreateMap<Client, ClientCreateDto>().ReverseMap();
            CreateMap<Client,ClientDto>().ReverseMap(); 
            CreateMap<Client,ClientUpdateDto>().ReverseMap();

            //Courier

            CreateMap<RegisterDto, CourierCreateDto>().ReverseMap();
            CreateMap<Courier, RegisterDto>().ReverseMap();
            CreateMap<Courier, CourierCreateDto>().ReverseMap();
            CreateMap<Courier, CourierDto>().ReverseMap();
            CreateMap<Courier, CourierUpdateDto>().ReverseMap();

            //EmployeeRole


            //Employee

            CreateMap<RegisterDto,EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, RegisterDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            //Backup

            CreateMap<BackUp, BackupDto>().ReverseMap();
            CreateMap<BackUp, BackupCreateDto>().ReverseMap();
            CreateMap<BackUp, BackupUpdateDto>().ReverseMap();
            //BackupStatus

            CreateMap<BackupStatus, BackupStatusDto>().ReverseMap();
            CreateMap<BackupStatus, BackupStatusCreateDto>().ReverseMap();
            CreateMap<BackupStatus, BackupStatusUpdateDto>().ReverseMap();

            //Area

            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, AreaCreateDto>().ReverseMap();
            CreateMap<Area, AreaUpdateDto>().ReverseMap();

            //shipmentStatus

            CreateMap<ShipmentStatus, ShipmentStatusDto>().ReverseMap();
            CreateMap<ShipmentStatus, ShipmentStatusCreateDto>().ReverseMap();
            CreateMap<ShipmentStatus, ShipmentStatusUpdateDto>().ReverseMap();

            //deliveryShipment

            CreateMap<Shipping, ShippingDto>().ReverseMap();
            CreateMap<Shipping, ShippingUpdateDto>().ReverseMap();
            CreateMap<Shipping, ShippingCreateDto>().ReverseMap();

            //Shipment
            CreateMap<Shipment, ShipmentDto>().ReverseMap();
            CreateMap<Shipment, ShipmentCreateDto>().ReverseMap();
            CreateMap<Shipment, ShipmentUpdateDto>().ReverseMap();

            //Vehicle
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Vehicle, VehicleEdit>().ReverseMap();
            ///invoice
            ///
            CreateMap<Invoice, InvoiceCreateDto>().ReverseMap();

        }
    }
}

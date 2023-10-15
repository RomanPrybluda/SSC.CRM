using AutoMapper;
using DAL.Entity;
using Domain.Services.InvoiceServices.DTO;

namespace Domain.Mappers
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, GetInvoiceResponse>();

            CreateMap<CreateInvoiceRequest, Invoice>();
            CreateMap<Invoice, CreateInvoiceResponse>();

            CreateMap<UpdateInvoiceRequest, Invoice>();
            CreateMap<Invoice, UpdateInvoiceResponse>();
        }
    }
}
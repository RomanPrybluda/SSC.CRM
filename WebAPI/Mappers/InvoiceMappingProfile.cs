using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
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
using AutoMapper;
using DAL.Entity;
using Domain.Services.DocumentService.DTO;

namespace Domain.Mappers
{
    public class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            CreateMap<Document, GetDocumentResponse>();

            CreateMap<CreateDocumentRequest, Document>();
            CreateMap<Document, CreateDocumentResponse>();

            CreateMap<UpdateDocumentRequest, Document>();
            CreateMap<Document, UpdateDocumentResponse>();
        }
    }
}
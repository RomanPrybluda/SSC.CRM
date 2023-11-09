using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
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
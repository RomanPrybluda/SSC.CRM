using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DocumentService
    {
        private readonly IRepository<Document> _repository;
        private readonly IMapper _mapper;

        public DocumentService(IRepository<Document> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDocumentResponse>> GetAllDocumentsAsync()
        {
            var documents = await _repository.GetAllQueryable().ToListAsync();

            if (documents is null)
                throw new CustomException(CustomExceptionType.NotFound, "No documents found.");

            var documentResponses = _mapper.Map<IEnumerable<GetDocumentResponse>>(documents);

            return documentResponses;
        }

        public async Task<GetDocumentResponse> GetDocumentByIdAsync(Guid id)
        {
            var document = await _repository.GetByIdAsync(id);

            if (document == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No document with ID {id}.");

            var documentResponse = _mapper.Map<GetDocumentResponse>(document);

            return documentResponse;
        }

        public async Task<CreateDocumentResponse> CreateDocumentAsync(CreateDocumentRequest request)
        {
            var document = _mapper.Map<Document>(request);

            var result = await _repository.CreateEntityAsync(document);
            await _repository.SaveChangesAsync();

            var documentResponse = _mapper.Map<CreateDocumentResponse>(result);

            return documentResponse;
        }

        public async Task<UpdateDocumentResponse> UpdateDocumentAsync(Guid id, UpdateDocumentRequest request)
        {
            var document = await _repository.GetByIdAsync(id);

            if (document is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No document with ID {id}.");

            _mapper.Map(request, document);

            var result = await _repository.UpdateEntityAsync(document);
            await _repository.SaveChangesAsync();

            var result2 = _mapper.Map<UpdateDocumentResponse>(result);

            return result2;
        }

        public async Task DeleteDocumentAsync(Guid id)
        {
            var document = await _repository.GetByIdAsync(id);

            if (document is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No document with ID {id}.");

            await _repository.DeleteEntityAsync(document);
            await _repository.SaveChangesAsync();
        }
    }
}

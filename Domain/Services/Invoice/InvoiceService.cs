using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services.InvoiceServices.DTO;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.InvoiceService
{
    public class InvoiceService
    {
        private readonly IRepository<Invoice> _repository;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetInvoiceResponse>> GetAllInvoicesAsync()
        {
            var invoices = await _repository.GetAllQueryable().ToListAsync();

            if (invoices is null)
                throw new CustomException(CustomExceptionType.NotFound, "No invoices found.");

            var invoiceResponses = _mapper.Map<IEnumerable<GetInvoiceResponse>>(invoices);

            return invoiceResponses;
        }

        public async Task<GetInvoiceResponse> GetInvoiceByIdAsync(Guid id)
        {
            var invoice = await _repository.GetByIdAsync(id);

            if (invoice == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No invoice with ID {id}.");

            var invoiceResponse = _mapper.Map<GetInvoiceResponse>(invoice);

            return invoiceResponse;
        }

        public async Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request)
        {
            var invoice = _mapper.Map<Invoice>(request);

            var result = await _repository.CreateEntityAsync(invoice);
            await _repository.SaveChangesAsync();

            var invoiceResponse = _mapper.Map<CreateInvoiceResponse>(result);

            return invoiceResponse;
        }

        public async Task<UpdateInvoiceResponse> UpdateInvoiceAsync(Guid id, UpdateInvoiceRequest request)
        {
            var invoice = await _repository.GetByIdAsync(id);

            if (invoice is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No invoice with ID {id}.");

            _mapper.Map(request, invoice);

            var result = await _repository.UpdateEntityAsync(invoice);
            await _repository.SaveChangesAsync();

            var invoiceResponse = _mapper.Map<UpdateInvoiceResponse>(result);

            return invoiceResponse;
        }

        public async Task DeleteInvoiceAsync(Guid id)
        {
            var invoice = await _repository.GetByIdAsync(id);

            if (invoice is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No invoice with ID {id}.");

            await _repository.DeleteEntityAsync(invoice);
            await _repository.SaveChangesAsync();
        }
    }
}

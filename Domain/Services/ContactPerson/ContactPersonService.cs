using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services.ContactPersonService.DTO;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.ContactPersonService
{
    public class ContactPersonService
    {
        private readonly IRepository<ContactPerson> _repository;
        private readonly IMapper _mapper;

        public ContactPersonService(IRepository<ContactPerson> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetContactPersonResponse>> GetAllContactPersonsAsync()
        {
            var contactPersons = await _repository.GetAllQueryable().ToListAsync();

            if (contactPersons is null)
                throw new CustomException(CustomExceptionType.NotFound, "No contact persons found.");

            var contactPersonResponses = _mapper.Map<IEnumerable<GetContactPersonResponse>>(contactPersons);

            return contactPersonResponses;
        }

        public async Task<GetContactPersonResponse> GetContactPersonByIdAsync(Guid id)
        {
            var contactPerson = await _repository.GetByIdAsync(id);

            if (contactPerson == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contact person with ID {id}.");

            var contactPersonResponse = _mapper.Map<GetContactPersonResponse>(contactPerson);

            return contactPersonResponse;
        }

        public async Task<CreateContactPersonResponse> CreateContactPersonAsync(CreateContactPersonRequest request)
        {
            var contactPerson = _mapper.Map<ContactPerson>(request);

            var result = await _repository.CreateEntityAsync(contactPerson);
            await _repository.SaveChangesAsync();

            var contactPersonResponse = _mapper.Map<CreateContactPersonResponse>(result);

            return contactPersonResponse;
        }

        public async Task<UpdateContactPersonResponse> UpdateContactPersonAsync(Guid id, UpdateContactPersonRequest request)
        {
            var contactPerson = await _repository.GetByIdAsync(id);

            if (contactPerson is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contact person with ID {id}.");

            _mapper.Map(request, contactPerson);

            var result = await _repository.UpdateEntityAsync(contactPerson);
            await _repository.SaveChangesAsync();

            var contactPersonResponse = _mapper.Map<UpdateContactPersonResponse>(result);

            return contactPersonResponse;
        }

        public async Task DeleteContactPersonAsync(Guid id)
        {
            var contactPerson = await _repository.GetByIdAsync(id);

            if (contactPerson is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contact person with ID {id}.");

            await _repository.DeleteEntityAsync(contactPerson);
            await _repository.SaveChangesAsync();
        }
    }
}

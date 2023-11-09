using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ClientService
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public ClientService(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetClientResponse>> GetAllClientsAsync()
        {
            var clients = await _repository.GetAllQueryable().ToListAsync();

            if (clients is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No clients");

            var clientResponses = _mapper.Map<IEnumerable<GetClientResponse>>(clients);

            return clientResponses;
        }

        public async Task<GetClientResponse> GetClientByIdAsync(Guid id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No client with ID {id}");

            var clientResponse = _mapper.Map<GetClientResponse>(client);

            return clientResponse;
        }

        public async Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request)
        {
            if (_repository.GetAllQueryable().Any(client => client.CompanyName == request.CompanyName))
            {
                throw new CustomException(CustomExceptionType.ClientAlreadyExist, $"Client is already with name {request.CompanyName}.");
            }

            var client = _mapper.Map<Client>(request);

            var result = await _repository.CreateEntityAsync(client);
            await _repository.SaveChangesAsync();

            var clientResponse = _mapper.Map<CreateClientResponse>(result);

            return clientResponse;
        }

        public async Task<UpdateClientResponse> UpdateClientAsync(Guid id, UpdateClientRequest request)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No client with {id} id.");

            if (_repository.GetAllQueryable().Any(x => x.CompanyName.ToLower() == request.CompanyName.ToLower()))
            {
                throw new CustomException(CustomExceptionType.ClientAlreadyExist, $"Client is already with name {request.CompanyName}.");
            }

            _mapper.Map(request, client);

            var result = await _repository.UpdateEntityAsync(client);
            await _repository.SaveChangesAsync();

            var clientResponse = _mapper.Map<UpdateClientResponse>(result);

            return clientResponse;
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No client with {id} id");

            await _repository.DeleteEntityAsync(client);
            await _repository.SaveChangesAsync();
        }
    }
}
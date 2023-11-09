using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ContractService
    {
        private readonly IRepository<Contract> _repository;
        private readonly IRepository<Client> _repositoryClient;
        private readonly IMapper _mapper;

        public ContractService(IRepository<Contract> repository, IMapper mapper, IRepository<Client> repositoryClient)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryClient = repositoryClient;
        }

        public async Task<IEnumerable<GetContractResponse>> GetAllContractsAsync()
        {
            var contracts = await _repository.GetAllQueryable().ToListAsync();

            if (contracts is null)
                throw new CustomException(CustomExceptionType.NotFound);

            var contractResponses = _mapper.Map<IEnumerable<GetContractResponse>>(contracts);

            return contractResponses;
        }

        public async Task<IEnumerable<GetContractResponse>> GetAllContractsByClientAsync(Guid id)
        {
            var client = await _repositoryClient.GetByIdAsync(id);

            if (client == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No client with ID {id}");

            var contracts = await _repository.GetAllQueryable().Where(c => c.ClientId == id).ToListAsync();

            if (contracts is null)
                throw new CustomException(CustomExceptionType.NotFound, "No contracts found.");

            var contractResponses = _mapper.Map<IEnumerable<GetContractResponse>>(contracts);

            return contractResponses;
        }

        public async Task<GetContractResponse> GetContractByIdAsync(Guid id)
        {
            var contract = await _repository.GetByIdAsync(id);

            if (contract == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contract with ID {id}.");

            var contractResponse = _mapper.Map<GetContractResponse>(contract);

            return contractResponse;
        }

        public async Task<CreateContractResponse> CreateContractAsync(CreateContractRequest request)
        {
            var contract = _mapper.Map<Contract>(request);

            var result = await _repository.CreateEntityAsync(contract);
            await _repository.SaveChangesAsync();

            var contractResponse = _mapper.Map<CreateContractResponse>(result);

            return contractResponse;
        }

        public async Task<UpdateContractResponse> UpdateContractAsync(Guid id, UpdateContractRequest request)
        {
            var contract = await _repository.GetByIdAsync(id);

            if (contract is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contract with ID {id}.");

            _mapper.Map(request, contract);

            var result = await _repository.UpdateEntityAsync(contract);
            await _repository.SaveChangesAsync();

            var result2 = _mapper.Map<UpdateContractResponse>(result);

            return result2;
        }

        public async Task DeleteContractAsync(Guid id)
        {
            var contract = await _repository.GetByIdAsync(id);

            if (contract is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No contract with ID {id}.");

            await _repository.DeleteEntityAsync(contract);
            await _repository.SaveChangesAsync();
        }
    }
}

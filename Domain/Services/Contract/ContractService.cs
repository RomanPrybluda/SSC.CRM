using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services.ContractService.DTO;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.ContractService
{
    public class ContractService
    {
        private readonly IRepository<Contract> _repository;
        private readonly IMapper _mapper;

        public ContractService(IRepository<Contract> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetContractResponse>> GetAllContractsAsync()
        {
            var contracts = await _repository.GetAllQueryable().ToListAsync();

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

using AutoMapper;
using DAL.Entity;
using Domain.Services.ContractService.DTO;

namespace Domain.Mappers
{
    public class ContractMappingProfile : Profile
    {
        public ContractMappingProfile()
        {
            CreateMap<Contract, GetContractResponse>();

            CreateMap<CreateContractRequest, Contract>();
            CreateMap<Contract, CreateContractResponse>();

            CreateMap<UpdateContractRequest, Contract>();
            CreateMap<Contract, UpdateContractResponse>();
        }
    }
}
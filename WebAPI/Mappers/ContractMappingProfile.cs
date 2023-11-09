using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
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
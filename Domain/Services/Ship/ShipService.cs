using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services.ShipService.DTO;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.ShipService
{
    public class ShipService
    {
        private readonly IRepository<Ship> _repository;
        private readonly IMapper _mapper;

        public ShipService(IRepository<Ship> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetShipResponse>> GetAllShipsAsync()
        {
            var ships = await _repository.GetAllQueryable().ToListAsync();

            if (ships is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ships");

            var shipResponses = _mapper.Map<IEnumerable<GetShipResponse>>(ships);

            return shipResponses;
        }

        public async Task<GetShipResponse> GetShipByIdAsync(Guid id)
        {
            var ship = await _repository.GetByIdAsync(id);

            if (ship == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with ID {id}");

            var shipResponse = _mapper.Map<GetShipResponse>(ship);

            return shipResponse;
        }

        public async Task<CreateShipResponse> CreateShipAsync(CreateShipRequest request)
        {
            if (_repository.GetAllQueryable().Any(ship => ship.ImoNumber == request.ImoNumber))
            {
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship is already with name {request.ShipName} and IMO {request.ImoNumber}.");
            }

            var ship = _mapper.Map<Ship>(request);

            var result = await _repository.CreateEntityAsync(ship);
            await _repository.SaveChangesAsync();

            var shipResponse = _mapper.Map<CreateShipResponse>(result);

            return shipResponse;
        }

        public async Task<UpdateShipResponse> UpdateShipAsync(Guid id, UpdateShipRequest request)
        {
            var ship = await _repository.GetByIdAsync(id);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with {id} id.");

            if (_repository.GetAllQueryable().Any(x => x.ShipName.ToLower() == request.ShipName.ToLower() &&
                                            x.ImoNumber == request.ImoNumber))
            {
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship is already with name {request.ShipName} and IMO {request.ImoNumber}.");
            }

            _mapper.Map(request, ship);

            var result = await _repository.UpdateEntityAsync(ship);
            await _repository.SaveChangesAsync();

            var shipResponse = _mapper.Map<UpdateShipResponse>(result);

            return shipResponse;
        }

        public async Task DeleteShipAsync(Guid id)
        {
            var ship = await _repository.GetByIdAsync(id);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with {id} id");

            await _repository.DeleteEntityAsync(ship);
            await _repository.SaveChangesAsync();
        }
    }
}
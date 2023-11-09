using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetOrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllQueryable().ToListAsync();

            if (orders is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No orders");

            var orderResponses = _mapper.Map<IEnumerable<GetOrderResponse>>(orders);

            return orderResponses;
        }

        public async Task<GetOrderResponse> GetOrderByIdAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No order with ID {id}");

            var orderResponse = _mapper.Map<GetOrderResponse>(order);

            return orderResponse;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);

            var result = await _repository.CreateEntityAsync(order);
            await _repository.SaveChangesAsync();

            var orderResponse = _mapper.Map<CreateOrderResponse>(result);

            return orderResponse;
        }

        public async Task<UpdateOrderResponse> UpdateOrderAsync(Guid id, UpdateOrderRequest request)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No order with {id} id.");

            _mapper.Map(request, order);

            var result = await _repository.UpdateEntityAsync(order);
            await _repository.SaveChangesAsync();

            var orderResponse = _mapper.Map<UpdateOrderResponse>(result);

            return orderResponse;
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No order with {id} id");

            await _repository.DeleteEntityAsync(order);
            await _repository.SaveChangesAsync();
        }
    }
}

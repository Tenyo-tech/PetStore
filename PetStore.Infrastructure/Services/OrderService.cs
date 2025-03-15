using PetStore.Business.Services;
using PetStore.Data.Dtos.Order;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<CreateOrderDto?> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            return await orderRepository.CreateOrderAsync(createOrderDto);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            return await orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await orderRepository.GetAllOrdersAsync();
        }

        public async Task<UpdateOrderDto?> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            return await orderRepository.UpdateOrderAsync(id, updateOrderDto);
        }

        public async Task<OrderDto?> DeleteOrderAsync(int id)
        {
            return await orderRepository.DeleteOrderAsync(id);
        }
    }
}

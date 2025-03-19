using PetStore.Data.Dtos.Order;

namespace PetStore.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto?> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDto>> GetOrdersAsync(int page, int take);
        Task<UpdateOrderDto?> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto);
        Task<OrderDto?> DeleteOrderAsync(int id);
    }
}

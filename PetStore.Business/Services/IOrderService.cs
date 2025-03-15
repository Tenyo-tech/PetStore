using PetStore.Data.Dtos.Order;

namespace PetStore.Business.Services
{
    public interface IOrderService
    {
        Task<CreateOrderDto?> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<UpdateOrderDto?> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto);
        Task<OrderDto?> DeleteOrderAsync(int id);
    }
}

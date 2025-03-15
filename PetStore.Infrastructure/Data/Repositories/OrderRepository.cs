using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Order;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public OrderRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateOrderDto?> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = mapper.Map<Order>(createOrderDto);
            order.Status = OrderStatus.Pending; // Default status for new orders

            petStoreDbContext.Orders.Add(order);
            await petStoreDbContext.SaveChangesAsync();

            return mapper.Map<CreateOrderDto>(order);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await petStoreDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await petStoreDbContext.Orders.ToListAsync();
            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<UpdateOrderDto?> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            var order = await petStoreDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                order.PurchaseDate = updateOrderDto.PurchaseDate;
                order.Status = updateOrderDto.Status;

                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateOrderDto>(order);
        }

        public async Task<OrderDto?> DeleteOrderAsync(int id)
        {
            var order = await petStoreDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                petStoreDbContext.Orders.Remove(order);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<OrderDto>(order);
        }
    }
}

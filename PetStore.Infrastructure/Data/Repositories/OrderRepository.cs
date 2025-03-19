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


        //This Method is desing for educational purposes 
        public async Task<OrderDto?> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            using var transaction = await petStoreDbContext.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    UserId = createOrderDto.UserId,
                    PurchaseDate = createOrderDto.PurchaseDate,
                    Status = OrderStatus.Pending
                };

                petStoreDbContext.Orders.Add(order);
                await petStoreDbContext.SaveChangesAsync();


                // Add Pets to Order
                if (createOrderDto.PetIds.Any())
                {
                    var pets = petStoreDbContext.Pets.Where(p => createOrderDto.PetIds.Contains(p.Id));
                    foreach (var pet in pets)
                    {
                        pet.OrderId = order.Id; // Associate pet with the order
                    }
                }

                // Add Food to Order
                foreach (var foodId in createOrderDto.FoodIds)
                {
                    petStoreDbContext.FoodOrders.Add(new FoodOrder
                    {
                        FoodId = foodId,
                        OrderId = order.Id
                    });
                }

                // Add Toys to Order
                foreach (var toyId in createOrderDto.ToyIds)
                {
                    petStoreDbContext.ToyOrders.Add(new ToyOrder
                    {
                        ToyId = toyId,
                        OrderId = order.Id
                    });
                }

                await petStoreDbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                // ✅ Reload the order with related data after saving
                // This is Eager type of Loading
                //Eager loading retrieves related entities in a single query using Include() and ThenInclude(). It loads the main entity and its related entities in one go.
                //⚡ When to Use?
                //    When you always need related data with the main entity.
                //    When you want to minimize the number of database queries.
                //❌ When Not to Use?
                //    If the related entities are very large, eager loading might fetch unnecessary data.
                //    If the relationships are rarely needed, you’re wasting resources.

                var savedOrder = await petStoreDbContext.Orders
                .Include(o => o.Pets) // Load pets directly
                .Include(o => o.Food)
                    .ThenInclude(fo => fo.Food)  // Load related Food
                .Include(o => o.Toys)
                    .ThenInclude(to => to.Toy)  // Load related Toy
                .FirstOrDefaultAsync(o => o.Id == order.Id);

                //✅ Explicit Loading
                //Explicit loading means manually retrieving related data only when needed. This avoids unnecessary data retrieval but requires multiple queries.

                //⚡ When to Use?
                //    When you don’t always need related data.
                //    When you want to optimize performance by loading data only when required.
                //❌ When Not to Use?
                //    If you need all related data upfront, explicit loading is less efficient than eager loading.

                var orderExplicit = await petStoreDbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

                if (orderExplicit != null)
                {
                    await petStoreDbContext.Entry(orderExplicit).Collection("Pets").LoadAsync();
                    await petStoreDbContext.Entry(orderExplicit).Collection("Food").LoadAsync();
                    await petStoreDbContext.Entry(orderExplicit).Collection("Toys").LoadAsync();
                }

                //✅ Lazy Loading
                //Lazy loading means related entities are not loaded initially, but when you access them for the first time, EF Core automatically loads them on demand.

                //⚡ When to Use?
                //    When related data is rarely needed, and you want to optimize performance.
                //    When dealing with deep relationships.
                //❌ When Not to Use?
                //    If you access related data in a loop, this will result in multiple database queries(N + 1 problem).
                //    If you are using Disconnected Objects (e.g., API calls), lazy loading doesn’t work because the DbContext is disposed after execution.

                var orderLazy = petStoreDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);

                if (orderLazy != null)
                {
                    // EF Core automatically loads Pets,Food,Toys when accessed!
                    var petsLazy = orderLazy.Pets;  // 🛑 Triggers a new database query
                    var foodsLazy = orderLazy.Food.Select(fo => fo.Food); // 🛑 Triggers a new database query
                    var toysLazy = orderLazy.Toys.Select(to => to.Toy); // 🛑 Triggers a new database query


                    //The N+1 Query Problem happens when lazy loading makes multiple queries instead of a single efficient one.
                    //Bad Example (Loop Triggers Multiple Queries)

                    foreach (var pet in orderLazy.Pets) // 🚨 Triggers a query for each pet
                    {
                        Console.WriteLine(pet.Description);
                    }


                    //Solution: Convert to a List Before Looping
                    var petsList = orderLazy.Pets.ToList(); // ✅ Loads all pets in one query

                    foreach (var pet in petsList)
                    {
                        Console.WriteLine(pet.Description); // ✅ No extra queries
                    }
                }

                var mappedOrder = mapper.Map<OrderDto>(savedOrder);
                return mappedOrder;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }


        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await petStoreDbContext.Orders
                .Include(o => o.Pets) // Include pets directly
                .Include(o => o.Food) // Include many-to-many food orders
                    .ThenInclude(fo => fo.Food)
                .Include(o => o.Toys) // Include many-to-many toy orders
                    .ThenInclude(to => to.Toy)
                .FirstOrDefaultAsync(o => o.Id == id);


            return mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await petStoreDbContext.Orders.OrderBy(o => o.PurchaseDate).ToListAsync();
            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        //Get Orders with pagination
        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int page, int take)
        {
            if (page > 0)
            {
                var orders = await petStoreDbContext.Orders
                .OrderBy(o => o.PurchaseDate)
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();

                return mapper.Map<IEnumerable<OrderDto>>(orders);
            }
            else
            {
                var orders = await petStoreDbContext.Orders.OrderBy(o => o.PurchaseDate).ToListAsync();
                return mapper.Map<IEnumerable<OrderDto>>(orders);
            }

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

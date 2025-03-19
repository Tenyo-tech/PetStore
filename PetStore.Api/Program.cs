using Microsoft.EntityFrameworkCore;
using PetStore.Business.Services;
using PetStore.Data.Context;
using PetStore.Data.DataProcessor;
using PetStore.Data.Repositories;
using PetStore.Infrastructure.Data.Contexts;
using PetStore.Infrastructure.Data.Repositories;
using PetStore.Infrastructure.DataProcessor;
using PetStore.Infrastructure.Mappings;
using PetStore.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var myAllowedSpecificOrigins = "myAllowedSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowedSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<PetStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetStoreConnection"));
});

builder.Services.AddDbContext<PetStoreConfigsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetStoreConfigConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(PetStoreMappings));

builder.Services.AddTransient<IDeserializer, Deserializer>();
builder.Services.AddTransient<ISerializer, Serializer>();
builder.Services.AddTransient<IPetStoreDbContext, PetStoreDbContext>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IBrandRepository, BrandRepository>();

builder.Services.AddTransient<IBreedService, BreedService>();
builder.Services.AddTransient<IBreedRepository, BreedRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IFoodService, FoodService>();
builder.Services.AddTransient<IFoodRepository, FoodRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddTransient<IPetRepository, PetRepository>();

builder.Services.AddTransient<IToyService, ToyService>();
builder.Services.AddTransient<IToyRepository, ToyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

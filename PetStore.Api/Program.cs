using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.DataProcessor;
using PetStore.Infrastructure.Data.Contexts;
using PetStore.Infrastructure.DataProcessor;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDeserializer, Deserializer>();
builder.Services.AddTransient<ISerializer, Serializer>();
builder.Services.AddTransient<IPetStoreDbContext, PetStoreDbContext>();


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

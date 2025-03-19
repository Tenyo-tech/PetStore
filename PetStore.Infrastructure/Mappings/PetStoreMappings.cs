using AutoMapper;
using PetStore.Data.Dtos;
using PetStore.Data.Dtos.Brand;
using PetStore.Data.Dtos.Breed;
using PetStore.Data.Dtos.Category;
using PetStore.Data.Dtos.Food;
using PetStore.Data.Dtos.Order;
using PetStore.Data.Dtos.Pet;
using PetStore.Data.Dtos.Toy;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Mappings
{
    public class PetStoreMappings : Profile
    {
        public PetStoreMappings()
        {
            // User Mapping
            CreateMap<CreateUserDto, User>();
            CreateMap<User, CreateUserDto>();

            // Brand Mapping
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, CreateBrandDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            // Breed Mapping
            CreateMap<CreateBreedDto, Breed>();
            CreateMap<Breed, CreateBreedDto>();

            CreateMap<BreedDto, Breed>();
            CreateMap<Breed, BreedDto>();

            CreateMap<UpdateBreedDto, Breed>();
            CreateMap<Breed, UpdateBreedDto>();

            // Category Mapping
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            // Food Mapping
            CreateMap<CreateFoodDto, Food>();
            CreateMap<Food, CreateFoodDto>();

            CreateMap<FoodDto, Food>();
            CreateMap<Food, FoodDto>();

            CreateMap<UpdateFoodDto, Food>();
            CreateMap<Food, UpdateFoodDto>();

            // Order Mappings
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, CreateOrderDto>();

            //CreateMap<OrderDto, Order>();
            //CreateMap<Order, OrderDto>();

            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, UpdateOrderDto>();

            // Mapping for Order -> OrderDto
            //CreateMap<Order, OrderDto>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            //    .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.Pets)) // Direct pets mapping
            //    .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src.Food.Select(fo => fo.Food))) // Many-to-Many
            //    .ForMember(dest => dest.Toys, opt => opt.MapFrom(src => src.Toys.Select(to => to.Toy))); // Many-to-Many

            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Foods, opt => opt.MapFrom(src => src.Food.Select(fo => fo.Food)))
            .ForMember(dest => dest.Toys, opt => opt.MapFrom(src => src.Toys.Select(to => to.Toy)));

            // Mapping for OrderDto -> Order (not commonly needed)
            //CreateMap<OrderDto, Order>()
            //    .ForMember(dest => dest.Food, opt => opt.Ignore()) // Many-to-many needs manual handling
            //    .ForMember(dest => dest.Toys, opt => opt.Ignore()) // Many-to-many needs manual handling
            //    .ForMember(dest => dest.Pets, opt => opt.Ignore());

            // Pet Mappings
            CreateMap<CreatePetDto, Pet>();
            CreateMap<Pet, CreatePetDto>();

            CreateMap<PetDto, Pet>();
            CreateMap<Pet, PetDto>();

            CreateMap<UpdatePetDto, Pet>();
            CreateMap<Pet, UpdatePetDto>();

            // Toy Mappings
            CreateMap<CreateToyDto, Toy>();
            CreateMap<Toy, CreateToyDto>();

            CreateMap<ToyDto, Toy>();
            CreateMap<Toy, ToyDto>();

            CreateMap<UpdateToyDto, Toy>();
            CreateMap<Toy, UpdateToyDto>();


        }
    }
}

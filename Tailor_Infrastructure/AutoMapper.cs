using AutoMapper;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Chat;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.MeasurementInformation;
using Tailor_Infrastructure.Dto.Notify;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Dto.UserSample;
using Task = Tailor_Domain.Entities.Task;

namespace Tailor_Infrastructure
{
    internal class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateChat, Chat>();
            CreateMap<UpdateChat, Chat>();
            CreateMap<Chat, ChatDto>();

            CreateMap<CreateInventory, Inventory>();
            CreateMap<UpdateInventory, Inventory>();
            CreateMap<Inventory, InventoryDto>();

            CreateMap<CreateInventoryCategory, InventoryCategory>();
            CreateMap<UpdateInventoryCategory, InventoryCategory>();
            CreateMap<InventoryCategory, InventoryCategoryDto>();

            CreateMap<CreateMeasurementInformation, MeasurementInformation>();
            CreateMap<UpdateMeasurementInformation, MeasurementInformation>();
            CreateMap<MeasurementInformation, MeasurementInformationDto>();

            CreateMap<CreateNotify, Notify>();
            CreateMap<UpdateNotify, Notify>();
            CreateMap<Notify, NotifyDto>();

            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductCategory, ProductCategory>();
            CreateMap<UpdateProductCategory, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<CreateSample, Sample>();
            CreateMap<UpdateSample, Sample>();
            CreateMap<Sample, SampleDto>();

            CreateMap<CreateTask, Task>();
            CreateMap<UpdateTask, Task>();
            CreateMap<Task, TaskDto>();

            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            CreateMap<User, UserDto>();

            CreateMap<CreateUserSample, UserSample>();
            CreateMap<UpdateUserSample, UserSample>();
            CreateMap<UserSample, UserSampleDto>();
        }
    }
}

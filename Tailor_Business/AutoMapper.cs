using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commands.ImageProduct;
using Tailor_Business.Commands.User;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Chat;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Dto.InventoryCategory;
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
            CreateMap<CreateUserCommand, CreateUser>();
            CreateMap<UpdateUserCommand, UpdateUser>();

            CreateMap<CreateTaskCommand, CreateTask>();
            CreateMap<UpdateTaskCommand, UpdateTask>();
            CreateMap<Task, TaskDto>();

            CreateMap<CreateProductCommand, CreateProduct>();
            CreateMap<UpdateProductCommand, UpdateProduct>();
            
            CreateMap<CreateNotifyCommand, CreateNotify>();
            CreateMap<UpdateNotifyCommand, UpdateNotify>();

            CreateMap<CreateProductCategoryCommand, CreateProductCategory>();
            CreateMap<UpdateProductCategoryCommand, UpdateProductCategory>();

            CreateMap<CreateInventoryCategoryCommand, CreateInventoryCategory>();
            CreateMap<UpdateInventoryCategoryCommand, UpdateInventoryCategory> ();
            
            CreateMap<CreateInventoryCommand, CreateInventory>();
            CreateMap<UpdateInventoryCommand, UpdateInventory> ();
            
            CreateMap<CreateUserSampleCommand, CreateUserSample>();
            CreateMap<UpdateUserSampleCommand, UpdateUserSample> ();

            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<UserSample, UserSampleDto>();

            CreateMap<User, UserDto>();

            CreateMap<Sample, SampleDto>();
            CreateMap<UpdateSampleCommand, UpdateSample>();
            CreateMap<CreateSampleCommand, CreateSample>();

            CreateMap<ImagesProduct, ImageDto>();
            CreateMap<CreateImageCommand, CreateImage>();

            CreateMap<CreateImageCommand, CreateImage>();
            CreateMap<Notify, NotifyDto>();
        }
    }
}

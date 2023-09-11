using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commands.User;
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
            CreateMap<CreateUserCommand, CreateUser>();
        }
    }
}

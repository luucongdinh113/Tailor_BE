﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.Chat;
using Tailor_Infrastructure.Dto.MeasurementInformation;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateProductCommand : IRequest<Unit>
    {
        #region param
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;
        #endregion
        public class CreateProductHanlderCommand : IRequestHandler<CreateProductCommand, Unit>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private IMapper _mapper;
            public CreateProductHanlderCommand(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var createProduct = _mapper.Map<CreateProduct>(request);
                _unitOfWorkRepository.ProductRepository.CreateProduct(createProduct);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}

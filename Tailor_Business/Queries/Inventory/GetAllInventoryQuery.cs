﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.Product
{
    public class GetAllInventoryQuery: IQuery<IEnumerable<InventoryDto>>
    {
        public class GetAllProductHandlerQuery : IQueryHandler<GetAllInventoryQuery, IEnumerable<InventoryDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetAllProductHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<IEnumerable<InventoryDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
            {
                var inventorys = await _unitOfWorkRepository.InventoryRepository.GetAsync();
                return inventorys.Select(c=>_mapper.Map<InventoryDto>(c)).OrderByDescending(c=>c.UpdatedDate).ToList();
            }
        }
    }
}

﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Repositories.IRepositories;
using Task = System.Threading.Tasks.Task;

namespace Tailor_Infrastructure.Repositories
{
    public class NotifyRepository : GenericRepository<Notify, int>, INotifyRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public NotifyRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        
    }
}

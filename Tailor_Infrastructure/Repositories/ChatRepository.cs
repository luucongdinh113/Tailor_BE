﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat, int>, IChatRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public ChatRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
    }
}

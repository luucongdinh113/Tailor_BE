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
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateTaskCommand : IRequest<Unit>
    {
        #region param
        public Guid? UserId { get; set; }

        public int? SampleId { get; set; }

        public int? ProductId { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
        #endregion
        public class CreateTaskHanlderCommand : IRequestHandler<CreateTaskCommand, Unit>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private IMapper _mapper;
            public CreateTaskHanlderCommand(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                var createTask = _mapper.Map<CreateTask>(request);
                _unitOfWorkRepository.TaskRepository.CreateTask(createTask);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}

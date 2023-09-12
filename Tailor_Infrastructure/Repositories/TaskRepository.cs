using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;
using Task = Tailor_Domain.Entities.Task;

namespace Tailor_Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<Task, int>, ITaskRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public TaskRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public void CreateTask(CreateTask inputTask)
        {
            var task = _mapper.Map<Task>(inputTask);
            if(inputTask.UserId!=null)
                _unitOfWorkRepository.UserRepository.GetById(inputTask.UserId.Value);
            if (inputTask.SampleId != null)
                _unitOfWorkRepository.SampleRepository.GetById(inputTask.SampleId.Value);
            if (inputTask.ProductId != null)
                _unitOfWorkRepository.ProductRepository.GetById(inputTask.ProductId.Value);
            _unitOfWorkRepository.TaskRepository.Insert(task);
        }
        public TaskDto UpdateTask(UpdateTask updateTask)
        {
            var task = _unitOfWorkRepository.TaskRepository.GetById(updateTask.Id);
            if (updateTask.UserId != null)
                _unitOfWorkRepository.UserRepository.GetById(updateTask.UserId.Value);
            if (updateTask.SampleId != null)
                _unitOfWorkRepository.SampleRepository.GetById(updateTask.SampleId.Value);
            if (updateTask.ProductId != null)
                _unitOfWorkRepository.ProductRepository.GetById(updateTask.ProductId.Value);
            Assign.Partial(updateTask, task);
            _unitOfWorkRepository.TaskRepository.Update(task);
            return _mapper.Map<TaskDto>(task);
        }
    }
}

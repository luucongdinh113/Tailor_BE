using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateInfoTask1Command : ICommand<TaskDto>
    {
        #region param
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int SampleId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; } = default!;
        public DateTime StartTime { get; set; } = default!;
        public DateTime EndTime { get; set; } = default!;
        public DateTime CompleteDate { get; set; } = default!;
        public DateTime DoneDate { get; set; } = default!;
        public string Image { get; set; } =default!;
        public string NoteCloth { get; set; } =default!;
        public decimal PriceCloth { get; set; } =default!;
        #endregion
        public class UpdateInfoTask1HandlerCommand : ICommandHandler<UpdateInfoTask1Command, TaskDto>
        {
            private readonly TaiLorContext _context;
            private readonly IMapper _mapper;
            public UpdateInfoTask1HandlerCommand(TaiLorContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<TaskDto> Handle(UpdateInfoTask1Command request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Task has Id = {request.Id}");
                var product = await _context.Products.Where(c => c.Id == task.ProductId).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Product has Id = {task.ProductId}");
                if (request.SampleId != 0)
                {
                    var sample = await _context.Samples.Where(c => c.Id == request.SampleId).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Sample has Id = {request.SampleId}");
                }
                task.StartTime = request.StartTime;
                task.EndTime = request.EndTime;
                task.SampleId = request.SampleId==0?null: request.SampleId;
                product.Name= request.Name;
                product.Price = request.Price;
                product.Images = request.Image;
                product.PriceCloth = request.PriceCloth;
                product.ProductCategoryId = request.ProductCategoryId;
                product.NoteCloth = request.NoteCloth;
                task.CompleteDate = request.CompleteDate;
                task.DoneDate = request.DoneDate;
                _context.Update(task);
                _context.Update(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}

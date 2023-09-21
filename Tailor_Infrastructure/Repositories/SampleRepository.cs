using AutoMapper;
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
    public class SampleRepository : GenericRepository<Sample, int>, ISampleRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public SampleRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public async Task CreateSampleAsync(CreateSample createSample)
        {
            var sample = _mapper.Map<Sample>(createSample);
            await _unitOfWorkRepository.SampleRepository.InsertAsync(sample);
        }

        public async Task<SampleDto> UpdateSampleAsync(UpdateSample updateSample)
        {
            var sample = await _unitOfWorkRepository.SampleRepository.GetByIdAsync(updateSample.Id);
            Assign.Partial(updateSample, sample);
            await _unitOfWorkRepository.SampleRepository.UpdateAsync(sample);
            return _mapper.Map<SampleDto>(sample);
        }
    }
}

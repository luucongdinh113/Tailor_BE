using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.MeasurementInformation;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class MeasurementInformationRepository : GenericRepository<MeasurementInformation, int>, IMeasurement_InformationRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public MeasurementInformationRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public int CreateMeasurement(CreateMeasurementInformation create)
        {
            var measurement = _mapper.Map<MeasurementInformation>(create);
            Insert(measurement);
            return measurement.Id;
        }
    }
}

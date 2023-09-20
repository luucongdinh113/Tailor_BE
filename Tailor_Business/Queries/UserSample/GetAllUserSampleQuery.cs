using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetAllUserSampleQuery : IRequest<IEnumerable<UserSampleDto>>
    {
        public class GetAllUserSampleHandlerQuery : IRequestHandler<GetAllUserSampleQuery, IEnumerable<UserSampleDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetAllUserSampleHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<IEnumerable<UserSampleDto>> Handle(GetAllUserSampleQuery request, CancellationToken cancellationToken)
            {
                var userSamples = _unitOfWorkRepository.UserSampleRepository.Get();
                return userSamples.Select(c=>_mapper.Map<UserSampleDto>(c)).ToList();
            }
        }
    }
}

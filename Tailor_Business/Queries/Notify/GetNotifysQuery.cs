using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Notify;
using Tailor_Infrastructure.Repositories;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.Notify
{
    public class GetNotifysQuery:IQuery<IEnumerable<NotifyDto>>
    {
        public Guid UserId { get; set; }
        public class GetNotifysHandlerQuery:IQueryHandler<GetNotifysQuery,IEnumerable<NotifyDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetNotifysHandlerQuery(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IEnumerable<NotifyDto>> Handle(GetNotifysQuery request, CancellationToken cancellationToken)
            {
                var notify=await _unitOfWork.NotifyRepository.GetAsync(c=>c.UserId.Equals(request.UserId),null,"Task");
                return notify.Select(c => _mapper.Map<NotifyDto>(c)).OrderByDescending(c=>c.CreatedDate).ToList();

            }
        }
    }
}

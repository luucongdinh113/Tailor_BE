using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Dtos;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.Chat
{
    public class GetChatByUserQuery:IRequest<IEnumerable<ChatDto>>
    {
        #region param
        public Guid UserId { get; set; }
        #endregion
        public class GetChatUserHandler : IRequestHandler<GetChatByUserQuery, IEnumerable<ChatDto>>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;
            public GetChatUserHandler(IUnitOfWorkRepository unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            Task<IEnumerable<ChatDto>> IRequestHandler<GetChatByUserQuery, IEnumerable<ChatDto>>.Handle(GetChatByUserQuery request, CancellationToken cancellationToken)
            {
                var chatDbs = _unitOfWork.ChatRepository.Get(c => c.ReceiverUserId.Equals(request.UserId));
                var chatDtos = new List<ChatDto>();
                foreach(var chatDb in chatDbs)
                {
                    chatDtos.Add(_mapper.Map<ChatDto>(chatDb));
                }    
                return Task.FromResult<IEnumerable<ChatDto>>(chatDtos);
            }
        }
    }
}

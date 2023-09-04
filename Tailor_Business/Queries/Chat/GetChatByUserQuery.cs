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
            public GetChatUserHandler(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            async Task<IEnumerable<ChatDto>> IRequestHandler<GetChatByUserQuery, IEnumerable<ChatDto>>.Handle(GetChatByUserQuery request, CancellationToken cancellationToken)
            {
                var a = _unitOfWork.ChatRepository.Get(c => c.ReceiverUserId.Equals(request.UserId));
                return new List<ChatDto>();
            }
        }
    }
}

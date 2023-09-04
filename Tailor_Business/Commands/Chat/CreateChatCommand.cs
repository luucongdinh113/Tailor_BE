//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Tailor_Business.Dtos;
//using Tailor_Domain.Entities;
//using Tailor_Infrastructure.Repositories.IRepositories;

//namespace Tailor_Business.Commands.Chat
//{
//    public class CreateChatCommand : IRequest<ChatDto>
//    {
//        #region Parameters
//        public Guid ReceiverUserId { get; set; }
//        public Guid SenderUserId { get; set; }
//        public string Content { get; set; } = default!;
//        public string UpLoadFile { get; set; } = default!;
//        #endregion

//        private readonly IUnitOfWorkRepository _unitOfWork;
//        public CreateChatCommand(IUnitOfWorkRepository unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public class CreateCommandHandler : IRequestHandler<CreateChatCommand, ChatDto>
//        {
//            public async Task<ChatDto> Handle(CreateChatCommand request, CancellationToken cancellationToken)
//            {
//                var newChat = new Chat()
//                {

//                };
//                return new ChatDto();
//            }
//        }
//    }
//}

namespace Tailor_Infrastructure.Dto.Chat
{
    public class ChatDto
    {
        public int Id { get; set; }
        public Guid ReceiverUserId { get; set; }
        public Tailor_Domain.Entities.User ReceiverUser { get; set; } = default!;

        public Guid SenderUserId { get; set; }
        public Tailor_Domain.Entities.User SenderUser { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string UpLoadFile { get; set; } = default!;
        public bool IsRead { get; set; } = false;
    }
}

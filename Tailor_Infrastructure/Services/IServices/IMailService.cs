using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.Mail;

namespace Tailor_Infrastructure.Services.IServices
{
    public interface IMailService
    {
        Task SendEmailAsync(MailInputType mailInput, CancellationToken ct);
    }
}

using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Tailor_Infrastructure.Dto.Mail;

namespace Tailor_Infrastructure.Services
{
    public class MailService: Tailor_Infrastructure.Services.IServices.IMailService
    {
        private readonly MailSetting _settings;
        public MailService(IOptions<MailSetting> setting)
        {
            _settings = setting.Value;
        }

        public async Task SendEmailAsync(MailInputType mailInput,CancellationToken ct)
        {
            var mail = new MimeMessage();
            #region Sender / Receiver
            // Sender
            mail.From.Add(new MailboxAddress(_settings.DisplayName, _settings.From));
            mail.Sender = new MailboxAddress(_settings.DisplayName, _settings.From);

            // Receiver
            mail.To.Add(MailboxAddress.Parse(mailInput.ToEmail));


            //// BCC
            //// Check if a BCC was supplied in the request
            //if (mailData.Bcc != null)
            //{
            //    // Get only addresses where value is not null or with whitespace. x = value of address
            //    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
            //        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            //}

            //// CC
            //// Check if a CC address was supplied in the request
            //if (mailData.Cc != null)
            //{
            //    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
            //        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            //}
            #endregion

            #region Content

            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailInput.Subject;
            if (mailInput.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailInput.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        body.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            body.HtmlBody = mailInput.Body;
            mail.Body = body.ToMessageBody();

            #endregion
            #region Send Mail

            using var smtp = new SmtpClient();

            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (_settings.UseStartTls)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
            }
            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
            await smtp.SendAsync(mail, ct);
            await smtp.DisconnectAsync(true, ct);

            #endregion
        }
    }
}

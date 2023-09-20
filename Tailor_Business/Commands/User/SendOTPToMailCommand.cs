using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Mail;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Business.Commands.User
{
    public class SendOTPToMailCommand:IRequest<bool>
    {
        public string UserName { get; set; } = default!;
        public class SendOTPToMailHandlerCommand : IRequestHandler<SendOTPToMailCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMailService _mailService;
            public SendOTPToMailHandlerCommand(IUnitOfWork unitOfWorkRepository,IMailService mailService)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mailService = mailService;
            }
            public async Task<bool> Handle(SendOTPToMailCommand request, CancellationToken cancellationToken)
            {
                var user=_unitOfWorkRepository.UserRepository.Get(c=>c.UserName==request.UserName).FirstOrDefault();
                if (user == null) return false;
                user.OTP = GenOTPRandom();
                user.ExpiredOTP = DateTime.UtcNow.AddMinutes(10);
                await _mailService.SendEmailAsync(new MailInputType
                {
                    ToEmail = user.Email,
                    Attachments = null,
                    Body = @"<html> <body> <p>Dear " + user.FirstName + " " + user.LastName + "</p>" +
                    "<p> Your OTP code is: " + user.OTP + "</p>" +
                    "<p> The OTP code is valid for 10 minutes from the time it is created. </p>" +
                    "<p> Thank you and have a good day.</p> </body> </html>",
                    Subject = "OTP code to reset password"
                },cancellationToken);
                _unitOfWorkRepository.UserRepository.Update(user);
                await _unitOfWorkRepository.SaveChangesAsync();
                return true;
            }
            private string GenOTPRandom()
            {
                Random random = new Random();

                // Tạo mã OTP ngẫu nhiên gồm 6 chữ số
                int otpLength = 6;
                string otp = "";

                for (int i = 0; i < otpLength; i++)
                {
                    otp += random.Next(0, 10).ToString();
                }
                return otp;
            }
        }
    }
}

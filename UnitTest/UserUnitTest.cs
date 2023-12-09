
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq.Expressions;
using Tailor_BE.Controllers;
using Tailor_Business.Commands.User;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task CreateUser_ReturnsOk_Successful()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var jwtServicMock= new Mock<IJWTService>();

            var controller = new UsersController(jwtServicMock.Object, mediatorMock.Object);

            var creatUserCommand = new Tailor_Business.Commands.User.CreateUserCommand
            {
                Email = "test@example.com", Phone = "123456789",
                Address = "123 Main St", FirstName = "John",
                LastName = "Doe", DateOfJoing = DateTime.Now,
                IsAdmin = false, NeckCircumference = 15.5,
                CheckCircumference = 30.0, WaistCircumference = 28.0,
                ButtCircumference = 40.0, ShoulderWidth = 18.0,
                UnderarmCircumference = 25.0, SleeveLength = 24.0,
                CuffCircumference = 8.0, ShirtLength = 30.0,
                ThighCircumference = 22.0, BottomCircumference = 38.0,
                ArmCircumference = 12.0, PantLength = 32.0,
                KneeHeight = 20.0, PantLegWidth = 10.0,
                Avatar = "avatar.jpg", UserName = "john_doe",
                PassWord = "password123", BirthDay = new DateTime(1990, 1, 1)
            };

            var cancellationToken = new CancellationToken();

            mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), cancellationToken))
                .ReturnsAsync(Unit.Value);
            unitOfWorkMock.Setup(u => u.UserRepository.CreateUser(It.IsAny<CreateUser>()));

            mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<Tailor_Domain.Entities.User>()))
                .Returns(new UserDto{});
            var result = await controller.CreateUser(creatUserCommand, cancellationToken);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var unit = okResult==null? Unit.Value: okResult?.Value;
            Assert.IsNotNull(unit);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Login_ReturnsOk_WhenMediatorFails()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var jwtServicMock = new Mock<IJWTService>();

            var controller = new UsersController(jwtServicMock.Object, mediatorMock.Object);

            var userName = "0346936427";
            var password = "03102001";

            jwtServicMock.Setup(service => service.GenerateJSONWebToken(It.IsAny<UserModel>()))
                .ReturnsAsync(It.IsAny<UserData>);

            // Act
            var result = await controller.Auth(userName, password);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task Login_ReturnsError_WhenMediatorFails()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var jwtServicMock = new Mock<IJWTService>();

            var controller = new UsersController(jwtServicMock.Object, mediatorMock.Object);

            var userName = "0346936427";
            var password = "abc123456";

            var userModel = new UserModel
            {
                UserName = userName,
                PassWord = password
            };

            var userData = new UserData
            {
            };

            jwtServicMock.Setup(service => service.GenerateJSONWebToken(It.IsAny<UserModel>()))
                 .ThrowsAsync(new Exception("Invalid passWord"));
            // Act
            var result = await controller.Auth(userName, password);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(400, errorResult.StatusCode);
            Assert.AreEqual("Invalid passWord", errorResult.Value);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ResetPassword_ValidRequest_ReturnsOk()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var jwtServicMock = new Mock<IJWTService>();

            var cancellationToken = new CancellationToken();

            var resetPwdCommand = new ResetPwdCommand
            {
                UserName = "TestUser",
                NewPassword = "newPassword",
                ConfirmNewPassword = "newPassword",
                OTPCode = "123456"
            };

            mediatorMock.Setup(m => m.Send(resetPwdCommand, cancellationToken))
                        .ReturnsAsync(true);

            var controller = new UsersController(jwtServicMock.Object, mediatorMock.Object);

            // Act
            var result = await controller.ResetPassword(resetPwdCommand, cancellationToken);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(true, okResult.Value);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ResetPassword_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var jwtServicMock = new Mock<IJWTService>();
            var cancellationToken = new CancellationToken();

            var resetPwdCommand = new ResetPwdCommand
            {
                UserName = "TestUser",
                NewPassword = "newPassword",
                ConfirmNewPassword = "differentPassword", // Triggering the validation exception
                OTPCode = "123456"
            };

            mediatorMock.Setup(m => m.Send(resetPwdCommand, cancellationToken))
                        .ThrowsAsync(new Exception("NewPassword must equal with ConfirmNewPassword"));

            var controller = new UsersController(jwtServicMock.Object, mediatorMock.Object);

            // Act
            var result = await controller.ResetPassword(resetPwdCommand, cancellationToken);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

    }
}
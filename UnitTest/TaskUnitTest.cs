
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tailor_BE.Controllers;
using Tailor_Business.Commands.User;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Repositories.IRepositories;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
    [TestClass]
    public class TaskUnitTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task CreateTask_ReturnsOk_Successful()
        {
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var controller = new TaskController(mediatorMock.Object);
            var createTaskCommand = new Tailor_Business.Commands.User.CreateTaskCommand
            {
                UserId = new Guid("08dbf064-a491-4989-8803-92eee38f47f6"),
                SampleId = 1,
                ProductId = 2,
                Content = "Test Task",
                Status = "Pending",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(1),
                Priority = 1,
                Index = 1,
                IsUseCloth = true,
                Note = "Test Note",
                Percent = 0
            };
            var cancellationToken = new CancellationToken();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateTaskCommand>(), cancellationToken))
                .ReturnsAsync(new TaskDto { });

            unitOfWorkMock.Setup(u => u.TaskRepository.CreateTask(It.IsAny<CreateTask>()))
                .Returns(new TaskDto{});

            mapperMock.Setup(m => m.Map<TaskDto>(It.IsAny<Tailor_Domain.Entities.Task>()))
                .Returns(new TaskDto { });

            var result = await controller.CreateTask(createTaskCommand, cancellationToken);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var taskDto = okResult.Value as TaskDto;
            Assert.IsNotNull(taskDto);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task CreateTask_ReturnsError_WhenMediatorFails()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var controller = new TaskController(mediatorMock.Object);

            var createTaskCommand = new Tailor_Business.Commands.User.CreateTaskCommand
            {
                UserId = new Guid("08dbf064-a491-4989-8803-92eee38f47f6"),
                SampleId = 1,
                ProductId = 2,
                Content = "Test Task",
                Status = "Pending",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(1),
                Priority = 1,
                Index = 1,
                IsUseCloth = true,
                Note = "Test Note",
                Percent = 100
            };

            var cancellationToken = new CancellationToken();

            mediatorMock.Setup(m => m.Send(It.IsAny<CreateTaskCommand>(), cancellationToken))
                .Throws(new Exception("Internal Server Error"));

            var result = await controller.CreateTask(createTaskCommand, cancellationToken);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(400, errorResult.StatusCode); 
        }


        [TestMethod]
        public async System.Threading.Tasks.Task UpdateTask_ReturnsOk_Successful()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var controller = new TaskController(mediatorMock.Object);

            var updateStatus = new Tailor_Business.Commands.User.UpdateStatusTaskCommand
            {
                Id=3,
                Status= "complete"
            };

            var cancellationToken = new CancellationToken();

            mediatorMock.Setup(m => m.Send(It.IsAny<UpdateStatusTaskCommand>(), cancellationToken))
                .ReturnsAsync(new TaskDto());

            unitOfWorkMock.Setup(u => u.TaskRepository.UpdateTask(It.IsAny<UpdateTask>()))
                .Returns(new TaskDto { });

            mapperMock.Setup(m => m.Map<TaskDto>(It.IsAny<Tailor_Domain.Entities.Task>()))
                .Returns(new TaskDto { });

            var result = await controller.UpdateStatusTask(updateStatus, cancellationToken);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var taskDto = okResult.Value as TaskDto;
            Assert.IsNotNull(taskDto);
        }


    }
}
using System;
using Xunit;
using Moq.EntityFrameworkCore;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Controllers;
using api.Entities;
using api.Data;
using FakeItEasy;
using api.DTOs;


namespace api.tests
{
  public class UsersControllerTests
  {
    // [Fact]
    // public async Task Register_BasicBehavior_Success()
    // {
    //   // Arrange 
    //   var repositoryStub = new Mock<DataContext>();
    //   repositoryStub.Setup(repo => repo.Register(It.IsAny<Guid>()))
    //     .ReturnsAsync((Item)null);

    //   var controller = new AccountController(repositoryStub.Object);

    //   // Act 
    //   var result = await controller.Register(UserDto);

    //   // Assert
    //   Assert.IsType<NotFoundResult>(result.Result);

    // }
  }
}

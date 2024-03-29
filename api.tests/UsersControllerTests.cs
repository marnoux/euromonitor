using System.Collections.Generic;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace api.tests
{
  public class UsersControllerTests
  {
    [Fact]
    public async Task GetUsersAsync_WithUserEntry_ReturnsSuccess()
    {
      // Arrange
      var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "Euromonitor")
            .Options;

      var _context = new DataContext(options);

      var controller = new UsersController(_context);

      // Insert seed data into the database using one instance of the context
      using (var context = new DataContext(options))
      {
        context.Users.Add(new AppUser
        {
          Id = 1,
          UserName = "UserName",
          Email = "TestEmail",
          FirstName = "TestFirstName",
          LastName = "TestLastName",
        });

        context.SaveChanges();
      }

      // Act
      var result = await controller.GetUsers();

      // Assert
      var items = Assert.IsType<List<AppUser>>(result.Value);
      Assert.Equal(1, items.Count);
    }
  }
}

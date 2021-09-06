using System.Collections.Generic;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace api.tests
{
  public class BooksControllerTests
  {
    [Fact]
    public async Task GetBooksAsync_WithBookEntry_ReturnsSuccess()
    {
      // Arrange
      var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "Euromonitor")
            .Options;

      var _context = new DataContext(options);

      var controller = new BooksController(_context);

      // Insert seed data into the database using one instance of the context
      using (var context = new DataContext(options))
      {
        context.Books.Add(new Book { Id = 1, Name = "TestBook", Text = "TestText", Price = 29 });
        context.SaveChanges();
      }

      // Act
      var result = await controller.GetBooks();

      // Assert
      var items = Assert.IsType<List<Book>>(result.Value);
      Assert.Equal(1, items.Count);
    }
  }
}

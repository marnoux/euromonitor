using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{

  public class BooksController : BaseApiController
  {
    private readonly DataContext _context;
    public BooksController(DataContext context)
    {
      _context = context;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
      return await _context.Books.ToListAsync();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
      return await _context.Books.FindAsync(id);
    }

    // POST: api/Book
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<BookDto>> PostBook(BookDto bookDto)
    {
      if (await BookExists(bookDto.Name))
      {
        return BadRequest("Book already exists");
      }

      var book = new Book
      {
        Name = bookDto.Name,
        Text = bookDto.Text,
        Price = bookDto.Price
      };

      _context.Books.Add(book);
      await _context.SaveChangesAsync();

      return new BookDto
      {
        Name = bookDto.Name,
        Text = bookDto.Text,
        Price = bookDto.Price
      };
    }

    // Add helper method to see if book exists before saving to db
    private async Task<bool> BookExists(string name)
    {
      return await _context.Books.AnyAsync(book => book.Name == name);
    }
  }
}
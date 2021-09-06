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

    // GET: api/books/1
    // This endpoint will be used to get details about all books 
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
      return await _context.Books.ToListAsync();
    }

    // GET: api/books/1
    // This endpoint will be used to get details about a specific book by passing in it's Id
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
      return await _context.Books.FindAsync(id);
    }

    // POST: api/Book
    // This endpoint will be used to create new books
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

    // Helper method to see if book exists before saving to db
    private async Task<bool> BookExists(string name)
    {
      return await _context.Books.AnyAsync(book => book.Name == name);
    }
  }
}
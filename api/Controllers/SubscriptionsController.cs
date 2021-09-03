using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Entities;
using api.DTOs;
using System;

namespace api.Controllers
{
  public class SubscriptionsController : BaseApiController
  {
    private readonly DataContext _context;
    public SubscriptionsController(DataContext context)
    {
      _context = context;
    }

    // [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions()
    {
      return await _context.Subscriptions.ToListAsync();
    }

    // [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Subscription>> GetSubscription(int id)
    {
      return await _context.Subscriptions.FindAsync(id);
    }

    // POST: api/Book
    // [Authorize]
    [HttpPost]
    public async Task<ActionResult<SubscriptionsDto>> PostSub(SubscriptionsDto subscriptionsDto)
    {
      // if (await BookExists(bookDto.Name))
      // {
      //   return BadRequest("Book already exists");
      // }

      var sub = new Subscription
      {
        DateAdded = DateTime.Now,
        BookId = subscriptionsDto.BookId,
        AppUserId = subscriptionsDto.AppUserId
      };

      _context.Subscriptions.Add(sub);
      await _context.SaveChangesAsync();

      return new SubscriptionsDto
      {
        BookId = subscriptionsDto.BookId,
        AppUserId = subscriptionsDto.AppUserId
      };
    }

    // Add helper method to see if book exists before saving to db
    private async Task<bool> SubExists(string name)
    {
      return await _context.Books.AnyAsync(book => book.Name == name);
    }
  }
}
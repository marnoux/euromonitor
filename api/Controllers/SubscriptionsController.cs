using System.Collections.Generic;
using System.Linq;
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
    [HttpGet("{userId}")]
    public IQueryable<Object> GetUserSubs(int userId)
    {
      return from s in _context.Subscriptions
             join b in _context.Books on s.BookId equals b.Id
             join u in _context.Users on s.AppUserId equals u.Id
             where s.AppUserId == userId
             select new
             {
               s.Id,
               s.DateAdded,
               b.Name,
               u.UserName
             };

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

    // DELETE subcriptions/1
    [HttpDelete("{id:int}")]
    public ActionResult<SubscriptionsDto> DeleteSub(int id)
    {
      if (id <= 0)
      {
        return BadRequest("Not a valid subscription");
      }

      Subscription sub = new Subscription() { Id = id };
      _context.Subscriptions.Attach(sub);
      _context.Subscriptions.Remove(sub);
      _context.SaveChanges();

      return Ok();
    }
  }
}
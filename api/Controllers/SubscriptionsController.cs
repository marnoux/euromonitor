using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Entities;

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
    
  }
}
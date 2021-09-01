using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
  public class Subscription
  {
    public int Id { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    public Book Book { get; set; }
    public int BookId { get; set; }
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
  }
}
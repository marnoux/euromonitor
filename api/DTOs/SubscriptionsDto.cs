using System;

namespace api.DTOs
{
  public class SubscriptionsDto
  {
    public int Id { get; set; }
    public DateTime DateAdded { get; set; }
    // public Book Book { get; set; }
    public int BookId { get; set; }
    // public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
  }
}
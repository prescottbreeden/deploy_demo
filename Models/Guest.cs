using System.ComponentModel.DataAnnotations;
using wedding_planner.Models;

namespace wedding_planner
{
  public class Guest
  {
    [Key]
    public int guest_id { get; set; }
    public int user_id { get; set; }
    public User User { get; set; }
    public int wedding_id { get; set; }
    public Wedding Wedding { get; set; }
  }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner
{
  public class Wedding
  {
    [Key]
    public int wedding_id { get; set; }
    [Required]
    public int user_id { get; set; }
    [Required]
    public int address_id { get; set; }
    [Required]
    public string wedder_one { get; set; }
    [Required]
    public string wedder_two { get; set; }
    [Required]
    public DateTime wedding_date { get; set; }
    public DateTime created_at { get; set; } = DateTime.Now;
    public DateTime updated_at { get; set; } = DateTime.Now;
  }
}
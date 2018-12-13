using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding_planner.Models
{
  public class User
  {
    [Key]
    public int user_id { get; set; }
    [Required]
    public string name { get; set; }
    [Required, EmailAddress]
    public string email { get; set; }
    [Required, DataType(DataType.Password)]
    public string password { get; set; }
    [Required, DataType(DataType.Password), Compare("password"), NotMapped]
    public string confirm { get; set; }
    public DateTime created_at { get; set; } = DateTime.Now;
    public DateTime updated_at { get; set; } = DateTime.Now;
  }
}
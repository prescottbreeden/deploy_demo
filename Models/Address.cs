using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
  public class Address
  {
    [Key]
    public int address_id { get; set; }
    public string street { get; set; }
    public string city  { get; set; }
    public string state { get; set; }
    public int zip_code { get; set; }
  }
}
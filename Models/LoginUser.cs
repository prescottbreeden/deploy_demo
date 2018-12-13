using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
  public class LoginUser
  {
    [Required]
    public string LogEmail { get; set; }
    [Required, DataType(DataType.Password)]
    public string LogPassword { get; set; }

    public string ValidationMessage { get; set; }
  }
}
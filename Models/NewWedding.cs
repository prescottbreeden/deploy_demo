using System;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models
{
  public class NewWedding
  {
    [Required]
    public int UserId { get; set; }
    [Required]
    public string WedderOne { get; set; }
    [Required]
    public string WedderTwo { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public int Zip { get; set; }
  }
}
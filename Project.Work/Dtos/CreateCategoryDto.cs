using Project.Work.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Work.Dtos;

public class CreateCategoryDto
{
    public string? Created_Date { get; set; }
    public string? Comment { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string? CategoryName { get; set; }
}
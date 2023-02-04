using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Work.Entities;

public class Items
{
    public Guid Id { get; set; }
    public string? Created_Date { get; set; }
    public string? Comment { get; set; }
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }
}
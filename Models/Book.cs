using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Models;

public class Book
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(typeof(decimal), "0.01", "999999999")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [StringLength(500)]
    public string? CoverImageUrl { get; set; }

    public bool IsFeatured { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

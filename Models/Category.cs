using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models;

public class Category
{
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Description { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}

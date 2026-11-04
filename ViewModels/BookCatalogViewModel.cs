using ECommerceProject.Models;

namespace ECommerceProject.ViewModels;

public class BookCatalogViewModel
{
    public IReadOnlyList<Book> Books { get; init; } = Array.Empty<Book>();
    public IReadOnlyList<Category> Categories { get; init; } = Array.Empty<Category>();
    public Category? SelectedCategory { get; init; }
    public string? SearchTerm { get; init; }
}

using ECommerceProject.Models;

namespace ECommerceProject.ViewModels;

public class HomeViewModel
{
    public IReadOnlyList<Book> FeaturedBooks { get; init; } = Array.Empty<Book>();
    public IReadOnlyList<Category> Categories { get; init; } = Array.Empty<Category>();
}

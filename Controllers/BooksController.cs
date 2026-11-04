using ECommerceProject.Data;
using ECommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Controllers;

public class BooksController : Controller
{
    private readonly BookstoreDbContext _db;

    public BooksController(BookstoreDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index(int? categoryId, string? searchTerm)
    {
        searchTerm = string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm.Trim();

        var categories = await _db.Categories
            .AsNoTracking()
            .OrderBy(category => category.Name)
            .ToListAsync();

        var selectedCategory = categoryId.HasValue
            ? categories.SingleOrDefault(category => category.Id == categoryId.Value)
            : null;

        if (categoryId.HasValue && selectedCategory is null)
        {
            return NotFound();
        }

        var booksQuery = _db.Books.AsNoTracking().Include(book => book.Category).AsQueryable();
        if (categoryId.HasValue)
        {
            booksQuery = booksQuery.Where(book => book.CategoryId == categoryId.Value);
        }

        if (searchTerm is not null)
        {
            booksQuery = booksQuery.Where(book => book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm));
        }

        return View(new BookCatalogViewModel
        {
            Categories = categories,
            SelectedCategory = selectedCategory,
            SearchTerm = searchTerm,
            Books = await booksQuery.OrderBy(book => book.Title).ToListAsync()
        });
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _db.Books
            .AsNoTracking()
            .Include(item => item.Category)
            .SingleOrDefaultAsync(item => item.Id == id);

        return book is null ? NotFound() : View(book);
    }
}

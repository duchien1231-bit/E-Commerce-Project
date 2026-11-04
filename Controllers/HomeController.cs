using ECommerceProject.Data;
using ECommerceProject.Models;
using ECommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerceProject.Controllers;

public class HomeController : Controller
{
    private readonly BookstoreDbContext _db;

    public HomeController(BookstoreDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel
        {
            FeaturedBooks = await _db.Books.AsNoTracking()
                .Include(book => book.Category)
                .Where(book => book.IsFeatured)
                .OrderBy(book => book.Title)
                .Take(4)
                .ToListAsync(),
            Categories = await _db.Categories.AsNoTracking()
                .OrderBy(category => category.Name)
                .ToListAsync()
        };

        return View(model);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

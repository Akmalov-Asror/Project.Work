using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Work.Entities;
using Project.Work.Models;
using System.Diagnostics;
using Project.Work.Context;
using Project.Work.Dtos;

namespace Project.Work.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Items.ToList());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult AddExpenses(CreateCategoryDto createExpenseDto)
    {
        if (!ModelState.IsValid)
            return View();

        var expense = new Items()
        {
            Amount = createExpenseDto.Amount,
            Comment = createExpenseDto!.Comment,
            Created_Date = createExpenseDto.Created_Date,
            Category = new Category
            {
                CategoryName = createExpenseDto.CategoryName
            },
        };
        _context.Items.Add(expense);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
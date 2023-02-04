using Microsoft.AspNetCore.Mvc;
using Project.Work.Dtos;
using Project.Work.Inerfaces;
using Project.Work.Services;

namespace Project.Work.Controllers;

public class ItemsController : Controller
{
    private readonly ExpenseService _expenseService;

    public ItemsController(ExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    public async Task<IActionResult> Index()
    {
       var date =  await _expenseService.GetExpensiveAsync();

       return View(date);
    }

    public async Task<IActionResult> CreateItems(CreateCategoryDto createCategoryDto)
    {
        if (!ModelState.IsValid)
            return View();
        var data = await _expenseService.CreateExpensiveAsync(createCategoryDto);
        return RedirectToAction("Index");
    }
}
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Project.Work.Dtos;
using Project.Work.Inerfaces;
using Project.Work.Services;

namespace Project.Work.Controllers;

public class ItemsController : Controller
{
    private readonly IExpenseService _expenseService;

    public ItemsController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    public async Task<IActionResult> Index()
    {
       var date =  await _expenseService.GetExpensesAsync();

       return View(date);
    }

    public async Task<IActionResult> CreateItems(CreateCategoryDto createCategoryDto)
    {
        
        if (!ModelState.IsValid)
            return View();

        var data = await _expenseService.CreateExpensiveAsync(createCategoryDto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteItems(Guid Id)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var data = _expenseService.DeleteExpensiveAsync(Id);
        return  RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateItems(UpdateItemDto updateItemDto)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var data = _expenseService.UpdateItemAsync(updateItemDto);
        return View();
    }
}
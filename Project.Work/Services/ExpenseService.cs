using JFA.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Project.Work.Context;
using Project.Work.Dtos;
using Project.Work.Entities;
using Project.Work.Inerfaces;

namespace Project.Work.Services;
public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _appDbContext;

    public ExpenseService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }   

    public async Task<Items> CreateExpensiveAsync(CreateCategoryDto createCategoryDto)
    {
        var data = new Items()
        {
            Amount = createCategoryDto.Amount,
            Comment = createCategoryDto!.Comment,
            Created_Date = createCategoryDto.Created_Date,
            Category = new Category
            {
                CategoryName = createCategoryDto.CategoryName
            },
        };
        _appDbContext.Items.Add(data);
        await _appDbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<Entities.Items>> GetExpensesAsync()
    {
        return await _appDbContext.Items.ToListAsync();
    }


    public async Task DeleteExpensiveAsync(Guid Id)
    {
        var data = await _appDbContext.Items.FirstOrDefaultAsync(u => u.Id == Id);
        _appDbContext.Items.Remove(data);
        await _appDbContext.SaveChangesAsync();
        
    }

    public async Task UpdateItemAsync(UpdateItemDto updateItemDto)
    {
        var data = await _appDbContext.Items.FirstOrDefaultAsync(u =>
            u.Amount == updateItemDto.Amount && u.Category.CategoryName == updateItemDto.CategoryName);
        _appDbContext.Items.Add(data);
        await _appDbContext.SaveChangesAsync();
    }
}
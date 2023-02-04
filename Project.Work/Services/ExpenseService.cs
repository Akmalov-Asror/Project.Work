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

    public async Task<List<Entities.Items>> GetExpensiveAsync()
    {
        return await _appDbContext.Items.ToListAsync();
    }

    public Task DeleteExpensiveAsync(DeleteItemDto deleteItemDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateItemAsync(UpdateItemDto updateItemDto)
    {
        throw new NotImplementedException();
    }
}
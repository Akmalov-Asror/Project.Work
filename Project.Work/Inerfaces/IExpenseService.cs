using Project.Work.Dtos;
using Project.Work.Entities;

namespace Project.Work.Inerfaces;

public interface IExpenseService
{
    Task<Items> CreateExpensiveAsync(CreateCategoryDto cteCategoryDto);
    Task<List<Entities.Items>> GetExpensiveAsync();
    Task DeleteExpensiveAsync(DeleteItemDto deleteItemDto);
    Task UpdateItemAsync(UpdateItemDto updateItemDto);
}
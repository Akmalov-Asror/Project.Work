using Project.Work.Dtos;
using Project.Work.Entities;

namespace Project.Work.Inerfaces;

public interface IExpenseService
{
    Task<Items> CreateExpensiveAsync(CreateCategoryDto cteCategoryDto);
    Task<List<Entities.Items>> GetExpensesAsync();
    Task DeleteExpensiveAsync(Guid Id);
    Task UpdateItemAsync(UpdateItemDto updateItemDto);
}
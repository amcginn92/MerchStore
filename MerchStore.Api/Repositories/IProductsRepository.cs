
using MerchStore.Api.Entities;

namespace MerchStore.Api.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetAsync(int id);
    Task CreateAsync(Product prod);
    Task UpdateAsync(Product updatedProd);
    Task DeleteAsync(int id);
}

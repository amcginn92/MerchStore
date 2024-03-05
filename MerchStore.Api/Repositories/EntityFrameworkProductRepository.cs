using MerchStore.Api.Data;
using MerchStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchStore.Api.Repositories;

public class EntityFrameworkProductRepository : IProductsRepository
{
    private readonly MerchStoreContext dbContext;

    public EntityFrameworkProductRepository(MerchStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await dbContext.Products.FindAsync(id);
    }

    public async Task CreateAsync(Product prod)
    {
        await dbContext.Products.AddAsync(prod);
        await dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Product updatedProd)
    {
        dbContext.Update(updatedProd);
        await dbContext.SaveChangesAsync();
    }
        public async Task DeleteAsync(int id)
    {
        await dbContext.Products.Where(prod => prod.Id == id)
            .ExecuteDeleteAsync();
    }
}
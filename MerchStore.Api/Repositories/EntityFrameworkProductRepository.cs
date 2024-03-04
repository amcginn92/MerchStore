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

    public IEnumerable<Product> getAll()
    {
        return dbContext.Products.AsNoTracking().ToList();
    }

    public Product? GetProd(int id)
    {
        return dbContext.Products.Find(id);
    }

    public void CreateProd(Product prod)
    {
        dbContext.Products.Add(prod);
        dbContext.SaveChanges();
    }
    public void Update(Product updatedProd)
    {
        dbContext.Update(updatedProd);
        dbContext.SaveChanges();
    }
        public void Delete(int id)
    {
        dbContext.Products.Where(prod => prod.Id == id)
            .ExecuteDelete();
    }
}
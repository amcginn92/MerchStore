
using MerchStore.Api.Entities;

namespace MerchStore.Api.Repositories;

public interface IProductsRepository
{
    public IEnumerable<Product> getAll();
    public Product? GetProd(int id);
    public void CreateProd(Product prod);
    public void Update(Product updatedProd);
    public void Delete(int id);
}

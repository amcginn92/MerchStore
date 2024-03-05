
using MerchStore.Api.Entities;

namespace MerchStore.Api.Repositories;
public class InMemProductsRepository : IProductsRepository
{

    private readonly List<Product> products = new(){

        new Product(){
            Id = 1,
            Name = "Tactical Flashlight",
            Category = "Tools",
            Price = 19.99M
        },
            new Product(){
            Id = 2,
            Name = "Ab Flexer",
            Category = "Exercise",
            Price = 29.99M
        },
            new Product(){
            Id = 3,
            Name = "Black Falcon 4k Drone",
            Category = "Tools",
            Price = 59.99M
        }

    };


    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Task.FromResult(products);
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await Task.FromResult(products.Find(product => product.Id == id));
    }

    public async Task CreateAsync(Product prod)
    {
        prod.Id = products.Max(cur => cur.Id) + 1;
        products.Add(prod);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Product updatedProd)
    {
        var index = products.FindIndex(prod => prod.Id == updatedProd.Id);
        products[index] = updatedProd;

        await Task.CompletedTask;
    }
    public async Task DeleteAsync(int id)
    {
        var index = products.FindIndex(prod => prod.Id == id);
        products.RemoveAt(index);

        await Task.CompletedTask;

    }

}

using MerchStore.Api.Entities;

namespace MerchStore.Api.Repositories;

public class InMemProductsRepository
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


    public IEnumerable<Product> getAll()
    {
        return products;
    }

    public Product? GetProd(int id)
    {
        return products.Find(product => product.Id == id);
    }

    public void CreateProd(Product prod)
    {
        prod.Id = products.Max(cur => cur.Id) + 1;
        products.Add(prod);
    }

    public void Update(Product updatedProd)
    {
        var index = products.FindIndex(prod => prod.Id == updatedProd.Id);
        products[index] = updatedProd;
    }
    public void Delete(int id)
    {
        var index = products.FindIndex(prod => prod.Id == id);
        products.RemoveAt(index);

    }

}
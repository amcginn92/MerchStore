using MerchStore.Api.Entities;

namespace MerchStore.Api.Endpoints;

public static class ProductsEndpoints
{

    const string getProductEndpointName = "getProduct";

    static List<Product> products = new(){

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
    public static RouteGroupBuilder MapProductEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/products");

        group.MapGet("/", () => products);

        group.MapGet("/{id}", (int id) =>
        {
            Product? prod = products.Find(prod => prod.Id == id);

            if (prod is null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Json(prod);
            }

        }).WithName(getProductEndpointName);

        group.MapPost("/", (Product product) =>
        {
            product.Id = products.Max(product => product.Id) + 1;
            products.Add(product);

            return Results.CreatedAtRoute(getProductEndpointName, new { id = product.Id }, product);
        });

        group.MapPut("/{id}", (Product updated, int id) =>
        {  //take updated product and id to replace

            Product? cur = products.Find(prod => prod.Id == id);    //find current product to update

            if (cur is null)
            {
                return Results.NotFound();
            }

            cur.Name = updated.Name;
            cur.Category = updated.Category;
            cur.Price = updated.Price;

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {

            Product? cur = products.Find(prod => prod.Id == id);

            if (cur is not null)
            {
                products.Remove(cur);
            }

            return Results.NoContent();

        });
        return group;

    }

}
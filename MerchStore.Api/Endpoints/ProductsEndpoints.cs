using MerchStore.Api.Entities;
using MerchStore.Api.Repositories;

namespace MerchStore.Api.Endpoints;

public static class ProductsEndpoints
{

    const string getProductEndpointName = "getProduct";

    public static RouteGroupBuilder MapProductEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemProductsRepository repo = new();


        var group = routes.MapGroup("/products");

        group.MapGet("/", () => repo.getAll());

        group.MapGet("/{id}", (int id) =>
        {
            Product? prod = repo.GetProd(id);

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
            repo.CreateProd(product);

            return Results.CreatedAtRoute(getProductEndpointName, new { id = product.Id }, product);
        });

        group.MapPut("/{id}", (Product updated, int id) =>
        {  //take updated product and id to replace

            Product? cur = repo.GetProd(id);    //find current product to update

            if (cur is null)
            {
                return Results.NotFound();
            }

            // cur.Name = updated.Name;
            // cur.Category = updated.Category;
            // cur.Price = updated.Price;

            updated.Id = cur.Id;
            repo.Update(updated);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {

            Product? cur = repo.GetProd(id);

            if (cur is not null)
            {
                repo.Delete(id);
            }

            return Results.NoContent();

        });
        return group;

    }

}
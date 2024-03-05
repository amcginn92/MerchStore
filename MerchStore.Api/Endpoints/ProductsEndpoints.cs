using MerchStore.Api.DTOs;
using MerchStore.Api.Entities;
using MerchStore.Api.Repositories;

namespace MerchStore.Api.Endpoints;

public static class ProductsEndpoints
{

    const string getProductEndpointName = "getProduct";

    public static RouteGroupBuilder MapProductEndpoints(this IEndpointRouteBuilder routes)
    {


        var group = routes.MapGroup("/products");


        group.MapGet("/", async (IProductsRepository repo) =>
            (await repo.GetAllAsync()).Select(prod => prod.AsDTO()));

        group.MapGet("/{id}", async (IProductsRepository repo, int id) =>
        {
            Product? prod = await repo.GetAsync(id);

            if (prod is null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(prod.AsDTO());
            }

        }).WithName(getProductEndpointName);

        group.MapPost("/", async (IProductsRepository repo, CreateProductDTO productDTO) =>
        {
            Product prod = new()
            {
                Name = productDTO.Name,
                Category = productDTO.Category,
                Price = productDTO.Price
            };

            await repo.CreateAsync(prod);

            return Results.CreatedAtRoute(getProductEndpointName, new { id = prod.Id }, prod);
        });

        group.MapPut("/{id}", async (IProductsRepository repo, UpdateProductDTO updatedProdDTO, int id) =>
        {  //take updated product and id to replace

            Product? curProd = (await repo.GetAsync(id));    //find current product to update

            if (curProd is null)
            {
                return Results.NotFound();
            }

            curProd.Name = updatedProdDTO.Name;
            curProd.Category = updatedProdDTO.Category;
            curProd.Price = updatedProdDTO.Price;


            await repo.UpdateAsync(curProd);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IProductsRepository repo, int id) =>
        {

            Product? cur = await repo.GetAsync(id);

            if (cur is not null)
            {
                await repo.DeleteAsync(id);
            }

            return Results.NoContent();

        });
        return group;

    }

}
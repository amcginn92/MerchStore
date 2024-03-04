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

        group.MapGet("/", (IProductsRepository repo) =>
            repo.getAll().Select(prod => prod.AsDTO()));

        group.MapGet("/{id}", (IProductsRepository repo, int id) =>
        {
            Product? prod = repo.GetProd(id);

            if (prod is null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(prod.AsDTO());
            }

        }).WithName(getProductEndpointName);

        group.MapPost("/", (IProductsRepository repo, CreateProductDTO productDTO) =>
        {
            Product prod = new()
            {
                Name = productDTO.Name,
                Category = productDTO.Category,
                Price = productDTO.Price
            };

            repo.CreateProd(prod);

            return Results.CreatedAtRoute(getProductEndpointName, new { id = prod.Id }, prod);
        });

        group.MapPut("/{id}", (IProductsRepository repo, UpdateProductDTO updatedProdDTO, int id) =>
        {  //take updated product and id to replace

            Product? curProd = repo.GetProd(id);    //find current product to update

            if (curProd is null)
            {
                return Results.NotFound();
            }

            curProd.Name = updatedProdDTO.Name;
            curProd.Category = updatedProdDTO.Category;
            curProd.Price = updatedProdDTO.Price;


            repo.Update(curProd);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IProductsRepository repo, int id) =>
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
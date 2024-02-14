using MerchStore.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new(){

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

app.MapGet("/products", () => products);
app.MapGet("/products/{id}", (int id) =>
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

});


app.Run();

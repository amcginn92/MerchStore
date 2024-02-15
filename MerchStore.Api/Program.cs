using MerchStore.Api.Endpoints;
using MerchStore.Api.Entities;
using MerchStore.Api.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductsRepository, InMemProductsRepository>();
var app = builder.Build();

app.MapProductEndpoints();

app.Run();

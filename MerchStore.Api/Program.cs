using MerchStore.Api.Data;
using MerchStore.Api.Endpoints;
using MerchStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductsRepository, EntityFrameworkProductRepository>();

var connString = builder.Configuration.GetConnectionString("MerchStoreContext");
builder.Services.AddSqlServer<MerchStoreContext>(connString);

var app = builder.Build();

//apply any missing migrations in db
app.Services.InitializeDb();

app.MapProductEndpoints();

app.Run();

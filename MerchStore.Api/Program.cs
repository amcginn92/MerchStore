using MerchStore.Api.Endpoints;
using MerchStore.Api.Entities;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapProductEndpoints();

app.Run();

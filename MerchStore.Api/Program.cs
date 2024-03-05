using MerchStore.Api.Data;
using MerchStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

//apply any missing migrations in db
await app.Services.InitializeDbAsync();

app.MapProductEndpoints();

app.Run();

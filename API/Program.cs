using API.Database;
using API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<DAL<Documento>>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

using API.Database;
using API.Endpoints;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>((options) =>
{
    options
    .UseSqlServer(builder.Configuration["ConnectionStrings:IntegracaoUneContAPI"])
            .UseLazyLoadingProxies();
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<DAL<Documento>>();
builder.Services.AddTransient<DocumentoService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.hom.une.digital/v2/UneCont") });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "http://localhost:5260",
            builder.Configuration["FrontendUrl"] ?? "http://localhost:5081"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));

var app = builder.Build();

app.UseCors("wasm");

app.AddEndpointsDocumentos();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

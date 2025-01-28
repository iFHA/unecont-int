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

var app = builder.Build();

app.AddEndpointsDocumentos();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

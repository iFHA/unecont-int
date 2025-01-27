using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database;
public class Context : DbContext
{
    public DbSet<Documento> Documentos { get; set; }
    private string ConnectionString = "Data Source=localhost;Initial Catalog=IntegracaoUneContAPI;User ID=sa;Password={sua_senha};TrustServerCertificate=True";
    public Context()
    { }
    public Context(DbContextOptions options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
        .UseSqlServer(ConnectionString)
        .UseLazyLoadingProxies();
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoFinanciamentoImobiliario.Models;

namespace ProjetoFinanciamentoImobiliario.Data
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Imovel> Imoveis { get; set; }
}
}
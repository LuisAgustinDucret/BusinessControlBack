
using BusinessControlBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessControlBackEnd.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Store> Store { get; set; }

        public DbSet<UnidadMedida> UnidadMedida { get; set; }

        public DbSet<Rubro> Rubro { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
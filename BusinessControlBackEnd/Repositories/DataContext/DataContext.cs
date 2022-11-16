
using BusinessControlBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessControlBackEnd.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Store> Stores { get; set; }
    }
}
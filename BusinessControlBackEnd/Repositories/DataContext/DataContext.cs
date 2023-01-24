
using BusinessControlBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace BusinessControlBackEnd.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { ChangeTracker.LazyLoadingEnabled = true; }

        public DbSet<Store> Store { get; set; }

        public DbSet<UnidadMedida> UnidadMedida { get; set; }

        public DbSet<Rubro> Rubro { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<CompoundProduct> CompoundProduct { get; set; }

        public DbSet<ProductStore> ProductStore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rubro>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Store>()
                .HasOne(s => s.Rubro)
                .WithMany(r => r.Stores)
                .HasForeignKey(s => s.RubroId)
                .HasPrincipalKey(r => r.Id);

            modelBuilder.Entity<Categoria>()
                 .HasKey(r => r.Id);


             modelBuilder.Entity<Product>()
                 .HasOne(s => s.Categoria)
                 .WithMany(r => r.Products)
                 .HasForeignKey(s => s.CategoriaId)
                 .HasPrincipalKey(r => r.Id);

             modelBuilder.Entity<Product>()
                 .HasOne(s => s.UnidadMedida)
                 .WithMany(r => r.Products)
                 .HasForeignKey(s => s.UnidadMedidaId)
                 .HasPrincipalKey(r => r.Id);

            modelBuilder.Entity<UnidadMedida>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<CompoundProduct>()
                .HasKey(cp => new { cp.CompoundProductId, cp.ProductId });

            modelBuilder.Entity<Product>()
                .ToTable(tb => tb.HasTrigger("tr_Product_Insert"));

            /* modelBuilder
                    .Entity<Post>()
                    .HasMany(p => p.Tags)
                    .WithMany(p => p.Posts)
                    .UsingEntity(j => j.ToTable("PostTags")); */


            modelBuilder.Entity<ProductStore>()
                        .HasKey(pt => new { pt.ProductId, pt.StoreId });

            modelBuilder.Entity<ProductStore>()
                        .HasOne(pt => pt.Product)
                        .WithMany(p => p.StoresFP)
                        .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductStore>()
                        .HasOne(pt => pt.Store)
                        .WithMany(t => t.ProductsFS)
                        .HasForeignKey(pt => pt.StoreId);


        }
    }
}
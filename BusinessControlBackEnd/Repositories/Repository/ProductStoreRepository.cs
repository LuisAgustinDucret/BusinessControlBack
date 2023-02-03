using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public class ProductStoreRepository : IProductStoreRepository
    {
        private readonly DataContext _context;

        public ProductStoreRepository(DataContext context)
        {
            _context = context;
        }
        public ProductStore CreateProductStore(ProductStore productStore)
        {
            if (productStore == null) throw new ArgumentNullException(nameof(productStore));
            return _context.ProductStore.Add(productStore).Entity;
        }

        public IEnumerable<ProductStore> GetAllProductStores()
        {
            return _context.ProductStore.ToList();
        }

        public ProductStore GetProductStoreById(int productStoreId)
        {
            return _context.ProductStore.FirstOrDefault(p => p.StoreId == productStoreId) ?? new ProductStore();
        }

        public void DeleteProductStore(int productId, int productStoreId)
        {
            var table = _context.ProductStore.FirstOrDefault(p => p.ProductId == productId && p.StoreId == productStoreId);

            _context.ProductStore.Remove(table);
            SaveChanges();
        }

        public ProductStore UpdateProductStore(ProductStore productStore)
        {
            ProductStore productStoreUpdated = _context.ProductStore.Update(productStore).Entity;
            SaveChanges();
            return productStoreUpdated;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
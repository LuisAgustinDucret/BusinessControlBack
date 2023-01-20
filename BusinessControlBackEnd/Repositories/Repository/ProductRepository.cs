using BusinessControlBackEnd.Models;
using System.Linq;

namespace BusinessControlBackEnd.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            return _context.Product.Add(product).Entity;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Product.ToList();
        }

        public IEnumerable<Product> GetAllParentProducts()
        {
            return _context.Product.Where(p => p.CompoundProductId != null).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id == id) ?? new Product();
        }


        public Product UpdateProduct(Product product)
        {
            Product productUpdated = _context.Product.Update(product).Entity;
            SaveChanges();
            return productUpdated;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
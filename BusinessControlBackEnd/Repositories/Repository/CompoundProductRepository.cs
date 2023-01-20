using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public class CompoundProductRepository : ICompoundProductRepository
    {
        private readonly DataContext _context;

        public CompoundProductRepository(DataContext context)
        {
            _context = context;
        }
        public CompoundProduct CreateCompoundProduct(CompoundProduct compoundProduct)
        {
            if (compoundProduct == null) throw new ArgumentNullException(nameof(compoundProduct));
            return _context.CompoundProduct.Add(compoundProduct).Entity;
        }

        public IEnumerable<CompoundProduct> GetAllCompoundProducts()
        {
            return _context.CompoundProduct.ToList();
        }

        public CompoundProduct GetCompoundProductById(int compoundProductId)
        {
            return _context.CompoundProduct.FirstOrDefault(p => p.CompoundProductId == compoundProductId) ?? new CompoundProduct();
        }

        public void DeleteCompoundProduct(int productId, int compoundProductId)
        {
            var table = _context.CompoundProduct.FirstOrDefault(p => p.ProductId == productId && p.CompoundProductId == compoundProductId);

            _context.CompoundProduct.Remove(table);
            SaveChanges();
        }

        public CompoundProduct UpdateCompoundProduct(CompoundProduct compoundProduct)
        {
            CompoundProduct compoundProductUpdated = _context.CompoundProduct.Update(compoundProduct).Entity;
            SaveChanges();
            return compoundProductUpdated;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
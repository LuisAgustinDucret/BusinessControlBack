using BusinessControlBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessControlBackEnd.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext context)
        {
            _context = context;
        }
        public Store CreateStore(Store store)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            return _context.Store.Add(store).Entity;
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Store.ToList();
        }

        public Store GetStoreById(int id)
        {
            return _context.Store.FirstOrDefault(p => p.Id == id) ?? new Store();
        }

        public Store UpdateStore(Store store)
        {
            Store storeUpdated = _context.Store.Update(store).Entity;
            SaveChanges();
            return storeUpdated;
        }

        public Store GetStoreWithProducts(int storeId)
        {
            var products = _context.Store
                                .Include(s => s.ProductsFS)
                                .ThenInclude(ps => ps.Product)
                                .FirstOrDefault(s => s.Id == storeId);


            return products;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

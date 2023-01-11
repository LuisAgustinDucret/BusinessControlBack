using BusinessControlBackEnd.Models;

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

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

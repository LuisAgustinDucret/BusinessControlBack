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
        public void CreateStore(Store store)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            _context.Stores.Add(store);
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }

        public Store GetStoreById(int id)
        {
            return _context.Stores.FirstOrDefault(p => p.Id == id) ?? new Store();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

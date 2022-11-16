using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface IStoreRepository
    {
        bool SaveChanges();

        IEnumerable<Store> GetAllStores();

        Store GetStoreById(int id);

        void CreateStore(Store store);
    }
}

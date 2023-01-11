using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface IStoreRepository
    {
        bool SaveChanges();

        IEnumerable<Store> GetAllStores();

        Store GetStoreById(int id);

        Store CreateStore(Store store);

        Store UpdateStore(Store store);
    }
}

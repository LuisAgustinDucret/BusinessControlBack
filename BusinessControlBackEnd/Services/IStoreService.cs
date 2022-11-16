using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IStoreService
    {
        StoreDTO GetStores(); //modificar, debe ser list.
        StoreDTO GetStoreById(int id);
        StoreDTO CreateStore(StoreDTO storeDTO);
    }
}

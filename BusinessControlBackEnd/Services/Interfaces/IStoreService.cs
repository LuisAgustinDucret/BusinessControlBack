using BusinessControlBackEnd.Dtos;


namespace BusinessControlBackEnd.Services
{
    public interface IStoreService
    {
        IEnumerable<StoreDTO> GetStores();
        StoreDTO GetStoreById(int id);
        StoreDTO CreateOrUpdateStore(StoreCreateUpdateDTO storeDTO);
        StoreWithProductsDTO GetStoreWithProducts(int storeId);
    }
}

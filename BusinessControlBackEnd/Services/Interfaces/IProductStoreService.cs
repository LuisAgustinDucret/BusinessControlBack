using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IProductStoreService
    {
        IEnumerable<StoreProductsDTO> GetProductStores();
        StoreProductsDTO GetProductStoreById(int productStoreId);
        void CreateOrUpdateProductStore(StoreProductsDTO productStoreDTO);
        void DeleteProductStore(int productId, int productStoreId);
    }
}

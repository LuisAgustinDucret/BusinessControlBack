using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IProductStoreService
    {
        IEnumerable<ProductStoreDTO> GetProductStores();
        ProductStoreDTO GetProductStoreById(int productStoreId);
        void CreateOrUpdateProductStore(ProductStoreDTO productStoreDTO);
        void DeleteProductStore(int productId, int productStoreId);
    }
}

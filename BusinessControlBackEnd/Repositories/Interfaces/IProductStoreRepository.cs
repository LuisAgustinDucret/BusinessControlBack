using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface IProductStoreRepository
    {
        bool SaveChanges();

        IEnumerable<ProductStore> GetAllProductStores();

        ProductStore GetProductStoreById(int productStoreId);

        ProductStore CreateProductStore(ProductStore productStore);

        ProductStore UpdateProductStore(ProductStore productStore);

        void DeleteProductStore(int productId, int productStoreId);
    }
}

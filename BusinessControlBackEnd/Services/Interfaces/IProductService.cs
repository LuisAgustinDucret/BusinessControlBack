using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();

        IEnumerable<ProductDTO> GetParentProducts();
        ProductDTO GetProductById(int id);
        ProductDTO CreateOrUpdateProduct(ProductCreateUpdateDTO productDTO);
        bool ExistPruductById(int id);
    }
}

using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProductById(int id);
        ProductDTO CreateOrUpdateProduct(ProductCreateUpdateDTO productDTO);
    }
}

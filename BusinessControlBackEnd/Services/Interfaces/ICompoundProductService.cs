using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface ICompoundProductService
    {
        IEnumerable<CompoundProductDTO> GetCompoundProducts();
        CompoundProductDTO GetCompoundProductById(int compoundProductId);
        void CreateOrUpdateCompoundProduct(CompoundProductDTO compoundproductDTO);
        void DeleteCompoundProduct(int productId, int compoundProductId);
    }
}

using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services.Interfaces
{
    public interface ICompoundProductService
    {
        IEnumerable<CompoundProductDTO> GetCompoundProducts();
        CompoundProductDTO GetCompoundProductByIds(int productId, int compoundProductId);
        void CreateOrUpdateCompoundProduct(CompoundProductDTO compoundproductDTO);
        void DeleteCompoundProduct(int productId, int compoundProductId);
    }
}

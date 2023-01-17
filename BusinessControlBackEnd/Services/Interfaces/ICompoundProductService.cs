using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services.Interfaces
{
    public interface ICompoundProductService
    {
        IEnumerable<CompoundProductDTO> GetCompoundProducts();
        CompoundProductDTO GetCompoundProductByIds(int productId, int compoundProductId);
        CompoundProductDTO CreateOrUpdateCompoundProduct(CompoundProductDTO compoundproductDTO);
    }
}

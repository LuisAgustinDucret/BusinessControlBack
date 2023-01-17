using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories.Interfaces
{
    public interface ICompoundProductRepository
    {
        bool SaveChanges();

        IEnumerable<CompoundProduct> GetAllCompoundProducts();

        CompoundProduct GetCompoundProductByIds(int productId, int compoundProductId);

        CompoundProduct CreateCompoundProduct(CompoundProduct compoundProduct);

        CompoundProduct UpdateCompoundProduct(CompoundProduct compoundProduct);
    }
}


using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface ICompoundProductRepository
    {
        bool SaveChanges();

        IEnumerable<CompoundProduct> GetAllCompoundProducts();

        CompoundProduct GetCompoundProductById(int compoundProductId);

        CompoundProduct CreateCompoundProduct(CompoundProduct compoundProduct);

        CompoundProduct UpdateCompoundProduct(CompoundProduct compoundProduct);

        void DeleteCompoundProduct(int productId, int compoundProductId);
    }
}


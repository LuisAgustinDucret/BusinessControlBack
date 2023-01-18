using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories

{
    public interface IProductRepository
    {
        bool SaveChanges();

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetAllParentProducts();

        Product GetProductById(int id);

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product);
    }
}

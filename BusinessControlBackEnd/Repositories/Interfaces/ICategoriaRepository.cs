using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface ICategoriaRepository
    {
        bool SaveChanges();

        IEnumerable<Categoria> GetAllCategorias();

        Categoria GetCategoriaById(int id);

        Categoria CreateCategoria(Categoria categoria);

        Categoria UpdateCategoria(Categoria categoria);
    }
}
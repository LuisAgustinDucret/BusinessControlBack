using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaDTO> GetCategorias();
        CategoriaDTO GetCategoriaById(int id);
        CategoriaDTO CreateOrUpdateCategoria(CategoriaDTO categoriaDTO);
    }
}

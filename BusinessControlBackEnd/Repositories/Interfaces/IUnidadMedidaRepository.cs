using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface IUnidadMedidaRepository
    {
        bool SaveChanges();

        IEnumerable<UnidadMedida> GetAllUnidadMedidas();

        UnidadMedida GetUnidadMedidaById(int id);

        UnidadMedida CreateUnidadMedida(UnidadMedida unidadmedida);

        UnidadMedida UpdateUnidadMedida(UnidadMedida unidadmedida);
    }
}
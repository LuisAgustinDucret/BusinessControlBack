using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IUnidadMedidaService
    {
        IEnumerable<UnidadMedidaDTO> GetUnidadMedidas();
        UnidadMedidaDTO GetUnidadMedidaById(int id);
        UnidadMedidaDTO CreateOrUpdateUnidadMedida(UnidadMedidaDTO unidadmedidaDTO);
        bool ExistUnidadMedidaById(int id);
    }
}

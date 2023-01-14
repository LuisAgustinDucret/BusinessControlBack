using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IRubroService
    {
        IEnumerable<RubroDTO> GetRubros();
        RubroDTO GetRubroById(int id);
        RubroDTO ValidarRubroById(int id);
        RubroDTO CreateOrUpdateRubro(RubroDTO rubroDTO);
    }
}

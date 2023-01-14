using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IRubroService
    {
        IEnumerable<RubroDTO> GetRubros();
        RubroDTO GetRubroById(int id);
        bool ExistRubroById(int id);
        RubroDTO CreateOrUpdateRubro(RubroDTO rubroDTO);
    }
}

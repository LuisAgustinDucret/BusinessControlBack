using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories.Interfaces
{
    public interface IRubroRepository
    {
        bool SaveChanges();

        IEnumerable<Rubro> GetAllRubros();

        Rubro GetRubroById(int id);

        Rubro CreateRubro(Rubro rubro);

        Rubro ValidarRubroById(int id);

        Rubro UpdateRubro(Rubro rubro);
    }
}

using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Repositories
{
    public interface IRubroRepository
    {
        bool SaveChanges();

        IEnumerable<Rubro> GetAllRubros();

        Rubro GetRubroById(int id);

        Rubro CreateRubro(Rubro rubro);

        Rubro UpdateRubro(Rubro rubro);
    }
}

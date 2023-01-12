using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories.Interfaces;

namespace BusinessControlBackEnd.Repositories.Repository
{
    public class RubroRepository : IRubroRepository
    {
        private readonly DataContext _context;

        public RubroRepository(DataContext context)
        {
            _context = context;
        }
        public Rubro CreateRubro(Rubro rubro)
        {
            if (rubro == null) throw new ArgumentNullException(nameof(rubro));
            return _context.Rubro.Add(rubro).Entity;
        }

        public IEnumerable<Rubro> GetAllRubros()
        {
            return _context.Rubro.ToList();
        }

        public Rubro GetRubroById(int id)
        {
            return _context.Rubro.FirstOrDefault(p => p.Id == id) ?? new Rubro();
        }

        public Rubro UpdateRubro(Rubro rubro)
        {
            Rubro rubroUpdated = _context.Rubro.Update(rubro).Entity;
            SaveChanges();
            return rubroUpdated;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
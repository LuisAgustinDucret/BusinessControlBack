using BusinessControlBackEnd.Models;
using System.Reflection.Metadata.Ecma335;

namespace BusinessControlBackEnd.Repositories
    {
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly DataContext _context;

        public UnidadMedidaRepository(DataContext context)
        {
            _context = context;
        }
        public UnidadMedida CreateUnidadMedida(UnidadMedida unidadmedida)
        {
            if (unidadmedida == null) throw new ArgumentNullException(nameof(unidadmedida));
            return _context.UnidadMedida.Add(unidadmedida).Entity;
        }

        public UnidadMedida UpdateUnidadMedida(UnidadMedida unidadmedida)
        {
            
            UnidadMedida unidadmedidasUpdated = _context.UnidadMedida.Update(unidadmedida).Entity;
            SaveChanges();
            return unidadmedidasUpdated;
        }

        public IEnumerable<UnidadMedida> GetAllUnidadMedidas()
        {
            return _context.UnidadMedida.ToList();
        }

        public UnidadMedida GetUnidadMedidaById(int id)
        {
            return _context.UnidadMedida.FirstOrDefault(p => p.Id == id) ?? new UnidadMedida();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

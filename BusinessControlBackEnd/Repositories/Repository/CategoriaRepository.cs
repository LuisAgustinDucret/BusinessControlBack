using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories.Interfaces;

namespace BusinessControlBackEnd.Repositories.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }
        public Categoria CreateCategoria(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));
            return _context.Categoria.Add(categoria).Entity;
        }

        public IEnumerable<Categoria> GetAllCategorias()
        {
            return _context.Categoria.ToList();
        }

        public Categoria GetCategoriaById(int id)
        {
            return _context.Categoria.FirstOrDefault(p => p.Id == id) ?? new Categoria();
        }

        public Categoria UpdateCategoria(Categoria categoria)
        {
            Categoria categoriaUpdated = _context.Categoria.Update(categoria).Entity;
            SaveChanges();
            return categoriaUpdated;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
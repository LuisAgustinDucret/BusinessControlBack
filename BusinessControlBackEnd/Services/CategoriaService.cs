using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories.Interfaces;

namespace BusinessControlBackEnd.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CategoriaDTO> GetCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(_repository.GetAllCategorias());
        }

        public CategoriaDTO GetCategoriaById(int id)
        {
            return _mapper.Map<CategoriaDTO>(_repository.GetCategoriaById(id));
        }

        public bool ExistCategoriaById(int id)
        {
            var categoriaDTO = _mapper.Map<CategoriaDTO>(_repository.GetCategoriaById(id));

            return categoriaDTO.Id != 0 ? true : false;
        }

        public CategoriaDTO CreateOrUpdateCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaModel = _mapper.Map<Categoria>(categoriaDTO);

            if (categoriaModel.Id == 0)
                _repository.CreateCategoria(categoriaModel);
            else
                _repository.UpdateCategoria(categoriaModel);

            _repository.SaveChanges();
            return _mapper.Map<CategoriaDTO>(categoriaModel);
        }

    }
}

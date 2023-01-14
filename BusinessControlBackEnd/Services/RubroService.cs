using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using BusinessControlBackEnd.Repositories.Interfaces;

namespace BusinessControlBackEnd.Services
{
    public class RubroService : IRubroService
    {
        private readonly IRubroRepository _repository;
        private readonly IMapper _mapper;

        public RubroService(IRubroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<RubroDTO> GetRubros()
        {
            return _mapper.Map<IEnumerable<RubroDTO>>(_repository.GetAllRubros());
        }

        public RubroDTO GetRubroById(int id)
        {

            return _mapper.Map<RubroDTO>(_repository.GetRubroById(id));
        }

        public RubroDTO ValidarRubroById(int id)
        {
            return _mapper.Map<RubroDTO>(_repository.ValidarRubroById(id));
        }

        public RubroDTO CreateOrUpdateRubro(RubroDTO rubroDTO)
        {
            var rubroModel = _mapper.Map<Rubro>(rubroDTO);

            if (rubroModel.Id == 0)
                _repository.CreateRubro(rubroModel);
            else
                _repository.UpdateRubro(rubroModel);

            _repository.SaveChanges();
            return _mapper.Map<RubroDTO>(rubroModel);
        }

    }
}
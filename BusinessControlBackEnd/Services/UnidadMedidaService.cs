using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Services
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _repository;
        private readonly IMapper _mapper;

        public UnidadMedidaService(IUnidadMedidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UnidadMedidaDTO> GetUnidadMedidas()
        {
            return _mapper.Map<IEnumerable<UnidadMedidaDTO>>(_repository.GetAllUnidadMedidas());
        }

        public UnidadMedidaDTO GetUnidadMedidaById(int id)
        {
            return _mapper.Map<UnidadMedidaDTO>(_repository.GetUnidadMedidaById(id));
        }

        public UnidadMedidaDTO CreateOrUpdateUnidadMedida(UnidadMedidaDTO unidadmedidaDTO)
        {
            var unidadmedidaModel = _mapper.Map<UnidadMedida>(unidadmedidaDTO);

            if (unidadmedidaModel.Id == 0)
                _repository.CreateUnidadMedida(unidadmedidaModel);
            else
                _repository.UpdateUnidadMedida(unidadmedidaModel);

            _repository.SaveChanges();
            return _mapper.Map<UnidadMedidaDTO>(unidadmedidaModel);
        }

    }
}


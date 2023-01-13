using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusinessControlBackEnd.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;
        public IRubroService _rubroService;

        public StoreService(IStoreRepository repository, IMapper mapper, IRubroService rubroService)
        {
            _repository = repository;
            _mapper = mapper;
            _rubroService = rubroService;
        }

        public IEnumerable<StoreDTO> GetStores()
        {
            var storesDTO = _mapper.Map<IEnumerable<StoreDTO>>(_repository.GetAllStores());
            ;
            foreach (var storeDTO in storesDTO)
            {
                storeDTO.Rubro = _rubroService.GetRubroById(storeDTO.RubroId);
            }

            return storesDTO;
        }

        public StoreDTO GetStoreById(int id)
        {
            var storeDTO = _mapper.Map<StoreDTO>(_repository.GetStoreById(id));
            storeDTO.Rubro = _rubroService.GetRubroById(storeDTO.RubroId);
            return storeDTO;
        }

        public StoreDTO CreateOrUpdateStore(StoreCreateUpdateDTO storeDTO)
        {
            var storeModel = _mapper.Map<Store>(storeDTO);

            if (storeModel.Id == 0)
                _repository.CreateStore(storeModel);
            else
                _repository.UpdateStore(storeModel);

            _repository.SaveChanges();
            return _mapper.Map<StoreDTO>(storeModel);
        }

    }
}

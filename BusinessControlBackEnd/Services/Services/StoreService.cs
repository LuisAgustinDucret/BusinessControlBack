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
            Validations(storeDTO);

            var storeModel = _mapper.Map<Store>(storeDTO);

            if (storeModel.Id == 0)
                _repository.CreateStore(storeModel);
            else
                _repository.UpdateStore(storeModel);

            _repository.SaveChanges();
            return _mapper.Map<StoreDTO>(storeModel);
        }


        public StoreWithProductsDTO GetStoreWithProducts(int storeId)
        {
            var store = _repository.GetStoreWithProducts(storeId);
            return _mapper.Map<StoreWithProductsDTO>(store);
        }


        public void Validations(StoreCreateUpdateDTO storeDTO)
        {
            if (!_rubroService.ExistRubroById(storeDTO.RubroId))
                throw new Exception($"El Rubro id: {storeDTO.RubroId},  no existe en la base de datos!");
        }
    }
}
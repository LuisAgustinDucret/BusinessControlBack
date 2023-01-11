using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<StoreDTO> GetStores()
        {
            return _mapper.Map<IEnumerable<StoreDTO>>(_repository.GetAllStores());
        }

        public StoreDTO GetStoreById(int id)
        {
            return _mapper.Map<StoreDTO>(_repository.GetStoreById(id));
        }

        public StoreDTO CreateOrUpdateStore(StoreDTO storeDTO)
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

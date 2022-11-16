using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Http;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Services
{
    public class StoreService
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
            //Mapper.Map<IEnumerable<SentEmailAttachment>, List<SentEmailAttachmentItem>>(someList);
            return _mapper.Map<IEnumerable<StoreDTO>>(_repository.GetAllStores());
        }

        public StoreDTO GetStoreById(int id)
        {
            return _mapper.Map<StoreDTO>(_repository.GetStoreById(id));
        }

        public StoreDTO CreateStore(StoreDTO storeDTO)
        {
            var storeModel = _mapper.Map<Store>(storeDTO);

            _repository.CreateStore(storeModel);
            _repository.SaveChanges();

            return _mapper.Map<StoreDTO>(storeModel);
        }
    }
}

﻿using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Services
{
    public interface IStoreService
    {
        IEnumerable<StoreDTO> GetStores();
        StoreDTO GetStoreById(int id);
        StoreDTO CreateOrUpdateStore(StoreDTO storeDTO);
    }
}

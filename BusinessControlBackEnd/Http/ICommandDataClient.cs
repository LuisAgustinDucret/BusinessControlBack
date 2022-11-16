using BusinessControlBackEnd.Dtos;

namespace BusinessControlBackEnd.Http
{
    public interface ICommandDataClient
    {
        Task SendStoreCommand(StoreDTO storeReadDTO);
    }
}

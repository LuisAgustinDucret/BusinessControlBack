using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Http;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private IStoreService _storeService;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;


        public StoreController(ILogger<StoreController> logger,
                                IStoreService storeService,
                                IMapper mapper,
                                ICommandDataClient commandDataClient)
        {
            _logger = logger;
            _mapper = mapper;
            _storeService = storeService;
            _commandDataClient = commandDataClient;
        }


        [HttpGet(Name = "GetStores")]
        public ActionResult<IEnumerable<StoreDTO>> GetStores()
        {
            Console.WriteLine("Getting Stores...");

            var stores = _storeService.GetStores();

            return Ok(_mapper.Map<IEnumerable<StoreDTO>>(stores));
        }

        [HttpGet("{id}", Name = "GetStoreById")]
        public ActionResult<StoreDTO> GetStoreById(int id)
        {
            Console.WriteLine("Getting Store...");

            var store = _storeService.GetStoreById(id);

            if (store != null)
            {
                return Ok(_mapper.Map<StoreDTO>(store));
            }

            return NotFound();
        }

        [HttpPost(Name = "PostStore")]
        public async Task<ActionResult<StoreDTO>> CreateStore(StoreDTO storeDTO)
        {
            Console.WriteLine("Creating Store...");

            var newStore = _storeService.CreateStore(storeDTO);

            try
            {
                await _commandDataClient.SendStoreCommand(storeDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetStoreById), new { Id = storeDTO.Id }, storeDTO);
        }
    }
}

using AutoMapper;
using BusinessControlBackEnd.Dtos;
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

        public StoreController(ILogger<StoreController> logger,
                                IStoreService storeService,
                                IMapper mapper
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _storeService = storeService;
        }


        [HttpGet]
        public IEnumerable<StoreDTO> GetStores()
        {
            Console.WriteLine("Getting Stores...");
            return _mapper.Map<IEnumerable<StoreDTO>>(_storeService.GetStores());

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
        public async Task<ActionResult<StoreDTO>> CreateOrUpdateStore(StoreCreateUpdateDTO storeDTO)
        {
            Console.WriteLine("Creating Store...");

            var newStore = _storeService.CreateOrUpdateStore(storeDTO);

            return CreatedAtRoute(nameof(GetStoreById), new { Id = newStore.Id }, newStore);
        }

    }
}

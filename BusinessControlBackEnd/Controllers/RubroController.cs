using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RubroController : ControllerBase
    {
        private readonly ILogger<RubroController> _logger;
        private IRubroService _rubroService;
        private readonly IMapper _mapper;

        public RubroController(ILogger<RubroController> logger,
                                IRubroService rubroService,
                                IMapper mapper
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _rubroService = rubroService;
        }


        [HttpGet]
        public IEnumerable<RubroDTO> GetRubros()
        {
            Console.WriteLine("Getting Rubros...");
            return _mapper.Map<IEnumerable<RubroDTO>>(_rubroService.GetRubros());

        }

        [HttpGet("{id}", Name = "GetRubroById")]
        public ActionResult<RubroDTO> GetRubroById(int id)
        {
            Console.WriteLine("Getting Rubro...");

            var rubro = _rubroService.GetRubroById(id);

            if (rubro != null)
            {
                return Ok(_mapper.Map<RubroDTO>(rubro));
            }

            return NotFound();
        }

        [HttpPost(Name = "PostRubro")]
        public async Task<ActionResult<RubroDTO>> CreateOrUpdateRubro(RubroDTO rubroDTO)
        {
            Console.WriteLine("Creating or Updating Rubro...");

            var newRubro = _rubroService.CreateOrUpdateRubro(rubroDTO);

            return CreatedAtRoute(nameof(GetRubroById), new { Id = newRubro.Id }, newRubro);
        }

    }
}
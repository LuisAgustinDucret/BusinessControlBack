using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly ILogger<UnidadMedidaController> _logger;
        private IUnidadMedidaService _unidadmedidaService;
        private readonly IMapper _mapper;

        public UnidadMedidaController(ILogger<UnidadMedidaController> logger,
                                IUnidadMedidaService unidadmedidaService,
                                IMapper mapper
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _unidadmedidaService = unidadmedidaService;
        }


        [HttpGet]
        public IEnumerable<UnidadMedidaDTO> GetUnidadMedidas()
        {
            Console.WriteLine("Getting Unidad Medidas...");
            return _mapper.Map<IEnumerable<UnidadMedidaDTO>>(_unidadmedidaService.GetUnidadMedidas());

        }

        [HttpGet("{id}", Name = "GetUnidadMedidaById")]
        public ActionResult<UnidadMedidaDTO> GetUnidadMedidaById(int id)
        {
            Console.WriteLine("Getting UnidadMedida...");

            var unidadmedida = _unidadmedidaService.GetUnidadMedidaById(id);

            if (unidadmedida != null)
            {
                return Ok(_mapper.Map<UnidadMedidaDTO>(unidadmedida));
            }

            return NotFound();
        }

        [HttpPost(Name = "PostUnidadMedida")]
        public async Task<ActionResult<UnidadMedidaDTO>> CreateOrUpdateUnidadMedida(UnidadMedidaDTO unidadmedidaDTO)
        {
            Console.WriteLine("Create Or Update UnidadMedida...");

            var newUnidadMedida = _unidadmedidaService.CreateOrUpdateUnidadMedida(unidadmedidaDTO);

            return CreatedAtRoute(nameof(GetUnidadMedidaById), new { Id = newUnidadMedida.Id }, newUnidadMedida);
        }

        [HttpDelete(Name = "DeleteUnidadMedida")]
        public async Task<ActionResult<UnidadMedidaDTO>> DeleteUnidadMedida(UnidadMedidaDTO unidadmedidaDTO)
        {
            Console.WriteLine("Create Or Update UnidadMedida...");

            var newUnidadMedida = _unidadmedidaService.CreateOrUpdateUnidadMedida(unidadmedidaDTO);

            return CreatedAtRoute(nameof(GetUnidadMedidaById), new { Id = newUnidadMedida.Id }, newUnidadMedida);
        }
    }
}
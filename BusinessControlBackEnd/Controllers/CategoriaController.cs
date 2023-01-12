using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller 
    {
        private readonly ILogger<CategoriaController> _logger;
        private ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ILogger<CategoriaController> logger,
                                ICategoriaService categoriaService,
                                IMapper mapper
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public IEnumerable<CategoriaDTO> GetCategorias()
        {
            Console.WriteLine("Getting Categorias...");
            return _mapper.Map<IEnumerable<CategoriaDTO>>(_categoriaService.GetCategorias());

        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        public ActionResult<CategoriaDTO> GetCategoriaById(int id)
        {
            Console.WriteLine("Getting Categoria...");

            var categoria = _categoriaService.GetCategoriaById(id);

            if (categoria != null)
            {
                return Ok(_mapper.Map<CategoriaDTO>(categoria));
            }

            return NotFound();
        }

        [HttpPost(Name = "PostCategoria")]
        public async Task<ActionResult<CategoriaDTO>> CreateOrUpdateCategoria(CategoriaDTO categoriaDTO)
        {
            Console.WriteLine("Creating Categoria...");

            var newCategoria = _categoriaService.CreateOrUpdateCategoria(categoriaDTO);

            return CreatedAtRoute(nameof(GetCategoriaById), new { Id = newCategoria.Id }, newCategoria);
        }

    }
}
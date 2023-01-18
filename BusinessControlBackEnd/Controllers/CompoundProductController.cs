using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Services;
using BusinessControlBackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompoundProductController : Controller
    {
        private ICompoundProductService _compoundProductService;
        private readonly ILogger<CompoundProductController> _logger;
        private readonly IMapper _mapper;

        public CompoundProductController(ILogger<CompoundProductController> logger,
                                IMapper mapper, ICompoundProductService compoundProductService
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _compoundProductService = compoundProductService;
        }

        [HttpPost(Name = "PostCompoundProduct")]
        public IActionResult CreateOrUpdateCompoundProduct(CompoundProductDTO compoundProductDTO)
        {
            Console.WriteLine("Creating CompoundProduct...");

            _compoundProductService.CreateOrUpdateCompoundProduct(compoundProductDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCompoundProduct(int productId, int compoundProductId)
        {
            Console.WriteLine("Searching CompoundProduct...");

            _compoundProductService.DeleteCompoundProduct(productId, compoundProductId);
            return Ok();
        }

    }
}

using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStoreController : Controller
    {
        private IProductStoreService _productStoreService;
        private readonly ILogger<ProductStoreController> _logger;
        private readonly IMapper _mapper;

        public ProductStoreController(ILogger<ProductStoreController> logger,
                                IMapper mapper,
                                IProductStoreService productStoreService
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _productStoreService = productStoreService;
        }

        [HttpPost(Name = "PostProductStore")]
        public IActionResult CreateOrUpdateProductStore(ProductStoreDTO productStoreDTO)
        {
            Console.WriteLine("Creating ProductStore...");

            _productStoreService.CreateOrUpdateProductStore(productStoreDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProductStore(int productId, int productStoreId)
        {
            Console.WriteLine("Searching ProductStore...");

            _productStoreService.DeleteProductStore(productId, productStoreId);
            return Ok();
        }

    }
}
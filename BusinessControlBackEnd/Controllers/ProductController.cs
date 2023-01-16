using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger,
                                IProductService productService,
                                IMapper mapper
                                )
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
        }


        [HttpGet]
        public IEnumerable<ProductDTO> GetProducts()
        {
            Console.WriteLine("Getting Products...");
            return _mapper.Map<IEnumerable<ProductDTO>>(_productService.GetProducts());

        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            Console.WriteLine("Getting Product...");

            var product = _productService.GetProductById(id);

            if (product != null)
            {
                return Ok(_mapper.Map<ProductDTO>(product));
            }

            return NotFound();
        }

        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult<ProductDTO>> CreateOrUpdateProduct(ProductCreateUpdateDTO productDTO)
        {

            Console.WriteLine("Creating Product...");

            var newProduct = _productService.CreateOrUpdateProduct(productDTO);

            return CreatedAtRoute(nameof(GetProductById), new { Id = newProduct.Id }, newProduct);
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(ProductCreateUpdateDTO productDTO)
        {
            Console.WriteLine("Delete Product...");

            var newProduct = _productService.CreateOrUpdateProduct(productDTO);

            return CreatedAtRoute(nameof(GetProductById), new { Id = newProduct.Id }, newProduct);
        }

    }
}

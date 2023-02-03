using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;

namespace BusinessControlBackEnd.Services
{
    public class ProductStoreService : IProductStoreService
    {
        private readonly IProductService _productService;
        private readonly IProductStoreRepository _repository;
        private readonly IMapper _mapper;


        public ProductStoreService(IProductStoreRepository repository, IMapper mapper, IProductService productService)
        {
            _repository = repository;
            _mapper = mapper;
            _productService = productService;
        }

        public IEnumerable<StoreProductsDTO> GetProductStores()
        {
            var productStoresDTO = _mapper.Map<IEnumerable<StoreProductsDTO>>(_repository.GetAllProductStores());

            return productStoresDTO;
        }

        public StoreProductsDTO GetProductStoreById(int compoundProductId)
        {
            var productStoreDTO = _mapper.Map<StoreProductsDTO>(_repository.GetProductStoreById(compoundProductId));

            return productStoreDTO;
        }

        public void DeleteProductStore(int productId, int compoundProductId)
        {
            _repository.DeleteProductStore(productId, compoundProductId);
        }

        public void CreateOrUpdateProductStore(StoreProductsDTO productStoreDTO)
        {
            StoreProductsDTO cpToDatabase;
            try
            {

                foreach (var productId in productStoreDTO.ProductsId)
                {
                    _repository.CreateProductStore(new ProductStore()
                    {
                        StoreId = productStoreDTO.StoreId,
                        ProductId = productId,

                    });
                }
            }
            catch (Exception ex)
            {
                // = $"Hubo un problema al querer generar los productos en el ProductStore con id {productStoreDTO.ProductStoreId}!";
                throw ex;
            }

            _repository.SaveChanges();
        }


    }
}
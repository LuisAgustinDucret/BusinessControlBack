using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;

namespace BusinessControlBackEnd.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ICategoriaService _categoriaService;
        public IUnidadMedidaService _unidadmedidaService;

        public ProductService(IProductRepository repository, IMapper mapper, ICategoriaService categoriaService, IUnidadMedidaService unidadmedidaService)
        {
            _repository = repository;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _unidadmedidaService = unidadmedidaService;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(_repository.GetAllProducts());
            
            foreach (var productDTO in productsDTO)
            {
                productDTO.Categoria = _categoriaService.GetCategoriaById(productDTO.CategoriaId);
                productDTO.UnidadMedida = _unidadmedidaService.GetUnidadMedidaById(productDTO.UnidadMedidaId);
    
            }

            return productsDTO;
        }

        public IEnumerable<ProductDTO> GetParentProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_repository.GetAllParentProducts());
        }

        public ProductDTO GetProductById(int id)
        {
            var productDTO = _mapper.Map<ProductDTO>(_repository.GetProductById(id));

            productDTO.Categoria = _categoriaService.GetCategoriaById(productDTO.CategoriaId);
            productDTO.UnidadMedida = _unidadmedidaService.GetUnidadMedidaById(productDTO.UnidadMedidaId);


            return productDTO;
        }


        public ProductDTO CreateOrUpdateProduct(ProductCreateUpdateDTO productDTO)
        {
            Validations(productDTO);

            if (!productDTO.IsCompoundProduct)
                productDTO.CompoundProductId = null;

            var productModel = _mapper.Map<Product>(productDTO);

            if (productModel.Id == 0)
                _repository.CreateProduct(productModel);
            else
                _repository.UpdateProduct(productModel);

            _repository.SaveChanges();
            return _mapper.Map<ProductDTO>(productModel);
        } 

        public void Validations(ProductCreateUpdateDTO productDTO)
        {
            if (!_categoriaService.ExistCategoriaById(productDTO.CategoriaId))
                throw new Exception($"La Categoria con id: {productDTO.CategoriaId},  no existe en la base de datos!");

            if (!_unidadmedidaService.ExistUnidadMedidaById(productDTO.UnidadMedidaId))
                throw new Exception($"La Unidad de Medida con id: {productDTO.UnidadMedidaId},  no existe en la base de datos!");
        }

        public bool ExistPruductById(int id)
        {
            var productDTO = _mapper.Map<ProductDTO>(_repository.GetProductById(id));

            return productDTO.Id != 0 ? true : false;
        }
    }
}
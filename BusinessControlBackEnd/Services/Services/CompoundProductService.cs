using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using BusinessControlBackEnd.Repositories.Interfaces;
using BusinessControlBackEnd.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BusinessControlBackEnd.Services
{
    public class CompoundProductService : ICompoundProductService
    {
        private readonly IProductService _productService;
        private readonly ICompoundProductRepository _repository;
        private readonly IMapper _mapper;


        public CompoundProductService(ICompoundProductRepository repository, IMapper mapper, IProductService productService)
        {
            _repository = repository;
            _mapper = mapper;
            _productService = productService;
        }

        public IEnumerable<CompoundProductDTO> GetCompoundProducts()
        {
            var compoundproductsDTO = _mapper.Map<IEnumerable<CompoundProductDTO>>(_repository.GetAllCompoundProducts());

            return compoundproductsDTO;
        }

        public CompoundProductDTO GetCompoundProductById(int compoundProductId)
        {
            var compoundproductDTO = _mapper.Map<CompoundProductDTO>(_repository.GetCompoundProductById(compoundProductId));

            return compoundproductDTO;
        }

        public void DeleteCompoundProduct(int productId, int compoundProductId)
        {
            _repository.DeleteCompoundProduct(productId, compoundProductId);
        }

        public void CreateOrUpdateCompoundProduct(CompoundProductDTO compoundproductDTO)
        {
            CompoundProductDTO cpToDatabase;
            try
            {

            foreach (var productId in compoundproductDTO.ProductsId)
            {
                _repository.CreateCompoundProduct(new CompoundProduct()
                {
                    CompoundProductId = compoundproductDTO.CompoundProductId,
                    ProductId = productId
                }) ;
            }
            } catch (Exception ex)
            {
                // = $"Hubo un problema al querer generar los productos en el CompoundProduct con id {compoundproductDTO.CompoundProductId}!";
                throw ex;
            }

            _repository.SaveChanges();
        }


    }
}
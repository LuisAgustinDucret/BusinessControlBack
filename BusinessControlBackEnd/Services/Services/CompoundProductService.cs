using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;
using BusinessControlBackEnd.Repositories;
using BusinessControlBackEnd.Repositories.Interfaces;
using BusinessControlBackEnd.Services.Interfaces;

namespace BusinessControlBackEnd.Services.Services
{
    public class CompoundProductService : ICompoundProductService
    {
        private readonly ICompoundProductRepository _repository;
        private readonly IMapper _mapper;


        public CompoundProductService(ICompoundProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public IEnumerable<CompoundProductDTO> GetCompoundProducts()
        {
            var compoundproductsDTO = _mapper.Map<IEnumerable<CompoundProductDTO>>(_repository.GetAllCompoundProducts());

            return compoundproductsDTO;
        }

        public CompoundProductDTO GetCompoundProductByIds(int productId, int compoundProductId)
        {
            var compoundproductDTO = _mapper.Map<CompoundProductDTO>(_repository.GetCompoundProductByIds(productId,compoundProductId));

            return compoundproductDTO;
        }

        public CompoundProductDTO CreateOrUpdateCompoundProduct(CompoundProductDTO compoundproductDTO)

        {
            var compoundproductModel = _mapper.Map<CompoundProduct>(compoundproductDTO);

            if (compoundproductModel.ProductId == 0)
                _repository.CreateCompoundProduct(compoundproductModel);
            else
                _repository.UpdateCompoundProduct(compoundproductModel);

            _repository.SaveChanges();
            return _mapper.Map<CompoundProductDTO>(compoundproductModel);
        }


    }
}
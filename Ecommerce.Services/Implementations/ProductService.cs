using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Repositories;

namespace Ecommerce.Services
{
    public class ProductService : BaseService, IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetList()
        {
            try
            {
                List<Product> modelList = await _productRepository.GetList();
                List<ProductViewModel> list = _mapper.Map<List<Product>, List<ProductViewModel>>(modelList);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

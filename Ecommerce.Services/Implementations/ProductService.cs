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

        public async Task<List<ProductViewModel>> GetList(IGridFilters filters)
        {
            try
            {
                List<Product> modelList = await _productRepository.GetList(filters);
                List<ProductViewModel> list = _mapper.Map<List<Product>, List<ProductViewModel>>(modelList);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ProductCategoryViewModel>> GetAllProductCategory()
        {
            try
            {
                List<ProductCategory> modelList = await _productRepository.GetAllProductCategory();
                List<ProductCategoryViewModel> list = _mapper.Map<List<ProductCategory>, List<ProductCategoryViewModel>>(modelList);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProductViewModel> GetProduct(int id){
            try
            {
                ProductViewModel product = _mapper.Map<ProductViewModel>(await _productRepository.GetProduct(id));
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task CreateProduct(ProductViewModel product)
        {
            try
            {
                Product mappedProduct = _mapper.Map<Product>(product);
                await _productRepository.CreateProduct(mappedProduct);
            }
            catch (Exception e)
            {
            }
        }
    }
}

using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateProductAsync(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

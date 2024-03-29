﻿using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Infrastructure.Context.Entities;
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

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<Product> result = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            Product? result = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<bool> CreateAsync(ProductDto product)
        {
            Product entity = _mapper.Map<ProductDto, Product>(product);
            bool result = await _productRepository.InsertAsync(entity);
            return result;
        }

        public async Task<bool> UpdateAsync(ProductDto product)
        {
            Product entity = _mapper.Map<ProductDto, Product>(product);
            bool result = await _productRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? entity = await _productRepository.GetByIdAsync(id);
            if (entity == null) return false;
            bool result = await _productRepository.DeleteAsync(entity);
            return result;
        }
    }
}

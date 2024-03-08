using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(ProductDto product);
        Task<bool> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int id);
    }
}

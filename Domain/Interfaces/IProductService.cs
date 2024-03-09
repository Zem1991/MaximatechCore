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
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(ProductDto product);
        Task<bool> UpdateAsync(ProductDto product);
        Task<bool> DeleteAsync(int id);
    }
}

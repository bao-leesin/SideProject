using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createDto);
        Task<ProductDto> UpdateProductAsync(string id, UpdateProductDto updateDto);
        Task DeleteProductAsync(string id);
        Task DeleteProductsAsync(DeleteMultiProductsDto deleteDto);
        Task<ProductDto> GetProductByIdAsync(string id);
        Task<PagedResult<ProductDto>> SearchProductsAsync(GetProductRequest request);
    }
} 
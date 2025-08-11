using Service.DTOs;
using Service.DTOs.Common;
using System.Threading.Tasks;

namespace Service.Interfaces.CoreService
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createDto);
    Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto updateDto);
    Task DeleteProductAsync(int id);
        Task DeleteProductsAsync(DeleteMultiProductsDto deleteDto);
    Task<ProductDto> GetProductByIdAsync(int id);
        Task<PagedResult<ProductDto>> SearchProductsAsync(GetProductRequest request);

    }
}
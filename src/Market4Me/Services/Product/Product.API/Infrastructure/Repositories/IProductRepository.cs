using Product.API.Model.Dto;

namespace Product.API.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(Guid productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(Guid productId);
    }
}

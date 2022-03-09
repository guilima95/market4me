using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.API.Infrastructure.EF;
using Product.API.Model;
using Product.API.Model.Dto;

namespace Product.API.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            ProductItem product = _mapper.Map<ProductDto, ProductItem>(productDto);
            if (product.Id != Guid.Empty)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductItem, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            try
            {
                ProductItem product = await _db.Products.FirstOrDefaultAsync(u => u.Id == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(Guid productId)
        {
            ProductItem product = await _db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<ProductItem> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
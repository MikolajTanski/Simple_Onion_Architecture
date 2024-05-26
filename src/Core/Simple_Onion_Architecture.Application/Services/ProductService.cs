using Simple_Onion_Architecture.Application.Abstractions.Repositories;
using Simple_Onion_Architecture.Application.Abstractions.Services;
using Simple_Onion_Architecture.Domain.Entities;

namespace Simple_Onion_Architecture.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetListAsync(
            enableTracking: false
            );
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetAsync(p => p.Id == id,
            enableTracking: true);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.Update(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetAsync(p => p.Id == id,
            enableTracking: true);
        
        if (product != null)
        {
            await _productRepository.Remove(product);
        }
    }
}
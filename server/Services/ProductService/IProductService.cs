using stepmedia_demo.EntityModels;

namespace stepmedia_demo.Services
{
    public interface IProductService : IBaseService<Product, ProductDto>
    {
        Task<Product> CreateNewAsync(ProductCreation input);
    }
}

using stepmedia_demo.EntityModels;
using stepmedia_demo.Repositories;
using stepmedia_demo.Services;
using stepmedia_demo.UnitOfWork;

namespace stepmedia_demo.Services
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IGenericRepository<Product> _reponsitory => _unitOfWork.ProductRepository;

        public async Task<Product> CreateNewAsync(ProductCreation input)
        {
            var newEntity = new Product()
            {
                ShopId = input.ShopId,
                Name = input.Name,
                UnitPrice = input.UnitPrice,
                CreatedDate = DateTime.UtcNow
            };

            return await CreateAsync(newEntity);
        }
    }
}

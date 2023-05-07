using Microsoft.AspNetCore.Mvc;
using stepmedia_demo.EntityModels;
using stepmedia_demo.Repositories;
using stepmedia_demo.Services;
using System.Web.Helpers;

namespace stepmedia_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<PaginationResult<ProductDto>> GetList(string? orderBy,
                                                     SortDirection? orderDirection,
                                                     int? page,
                                                     int? pageSize)
        {
            return await _productService.GetListAsync(orderBy, orderDirection, page, pageSize, s => new ProductDto
            {
                Id = s.Id,
                ShopId = s.ShopId,
                Name = s.Name,
                UnitPrice = s.UnitPrice,
                CreatedDate = s.CreatedDate,
            });
        }

        [HttpPost]
        public async Task<ProductResponse> Create(ProductCreation model)
        {
            var res = new ProductResponse() { Status = "failed" };
            if (!ModelState.IsValid)
                return res;

            var newProduct = await _productService.CreateNewAsync(model);
            if (newProduct != null && newProduct.Id > 0)
            {
                res.ID = newProduct.Id;
                res.Status = "success";
                res.TS = newProduct.CreatedDate.ToString();
            }

            return res;
        }
    }
}
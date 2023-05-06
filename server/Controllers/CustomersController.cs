using Microsoft.AspNetCore.Mvc;
using stepmedia_demo.EntityModels;
using stepmedia_demo.Services;

namespace stepmedia_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> Get()
        {
            return (await _customerService.FindAsync()).Select(s => new CustomerDto { Id = s.Id, FullName = s.FullName, Email = s.Email, DoB = s.DoB, CreatedDate = s.CreatedDate }).ToList();
        }
    }
}
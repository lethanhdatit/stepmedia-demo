using stepmedia_demo.EntityModels;
using stepmedia_demo.Repositories;
using System.Web.Helpers;

namespace stepmedia_demo.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<PaginationResult<CustomerDto>> GetListAsync(string? orderBy = null!,
                                            SortDirection? orderDirection = SortDirection.Ascending,
                                            int? page = null,
                                            int? pageSize = null);
        Task<Customer> CreateNewAsync(CustomerCreation input);
    }
}

using Microsoft.EntityFrameworkCore;
using stepmedia_demo.EntityModels;
using stepmedia_demo.Repositories;
using stepmedia_demo.UnitOfWork;
using System.Web.Helpers;

namespace stepmedia_demo.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IGenericRepository<Customer> _reponsitory => _unitOfWork.CustomerRepository;

        public async Task<Customer> CreateNewAsync(CustomerCreation input)
        {
            var newEntity = new Customer()
            {
                FullName = input.FullName,
                Email = input.Email,
                DoB = input.DoB,
                CreatedDate = DateTime.UtcNow
            };

            return await CreateAsync(newEntity);
        }

        public async Task<PaginationResult<CustomerDto>> GetListAsync(string? orderBy,
                                            SortDirection? orderDirection,
                                            int? page,
                                            int? pageSize)
        {
            var entities = _reponsitory.Find(null!, orderBy!, orderDirection, "", page, pageSize);

            return new PaginationResult<CustomerDto>()
            {
                TotalCount = entities.TotalCount,
                FilteredCount = entities.FilteredCount,
                PagedData = await entities.PagedData.Select(s => new CustomerDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    DoB = s.DoB,
                    CreatedDate = DateTime.UtcNow
                }).ToListAsync(),
            };
        }
    }
}

using stepmedia_demo.EntityModels;
using stepmedia_demo.Repositories;
using stepmedia_demo.UnitOfWork;

namespace stepmedia_demo.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IGenericRepository<Customer> _reponsitory => _unitOfWork.CustomerRepository;
    }
}

using GoldBusinessManagementApp.Manager.Base;
using GoldBusinessManagementApp.Manager.Contracts;
using GoldBusinessManagementApp.Model.Models;
using GoldBusinessManagementApp.Repository.Contracts;

namespace GoldBusinessManagementApp.Manager
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<ICollection<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }
    }
}

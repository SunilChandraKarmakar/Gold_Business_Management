using GoldBusinessManagementApp.Model.Models;

namespace GoldBusinessManagementApp.Repository.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<ICollection<Customer>> GetAll();
    }
}

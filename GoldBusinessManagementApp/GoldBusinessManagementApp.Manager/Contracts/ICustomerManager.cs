using GoldBusinessManagementApp.Model.Models;

namespace GoldBusinessManagementApp.Manager.Contracts
{
    public interface ICustomerManager : IBaseManager<Customer>
    {
        Task<ICollection<Customer>> GetAll();
    }
}

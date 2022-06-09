using GoldBusinessManagementApp.Model.Models;

namespace GoldBusinessManagementApp.Manager.Contracts
{
    public interface IProductManager : IBaseManager<Product>
    {
        Task<ICollection<Product>> GetAll();
    }
}

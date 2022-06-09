using GoldBusinessManagementApp.Model.Models;

namespace GoldBusinessManagementApp.Repository.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<ICollection<Product>> GetAll();
    }
}
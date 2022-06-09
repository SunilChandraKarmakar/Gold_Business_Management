using GoldBusinessManagementApp.Manager.Base;
using GoldBusinessManagementApp.Manager.Contracts;
using GoldBusinessManagementApp.Model.Models;
using GoldBusinessManagementApp.Repository.Contracts;

namespace GoldBusinessManagementApp.Manager
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<ICollection<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
    }
}
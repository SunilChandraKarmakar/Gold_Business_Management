using GoldBusinessManagementApp.Model.Models;
using GoldBusinessManagementApp.Repository.Base;
using GoldBusinessManagementApp.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GoldBusinessManagementApp.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public override async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.Customer).Where(c => !c.IsDeleted).ToListAsync();
        }
    }
}
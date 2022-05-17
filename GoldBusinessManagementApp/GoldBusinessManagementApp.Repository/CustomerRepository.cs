using GoldBusinessManagementApp.Model.Models;
using GoldBusinessManagementApp.Repository.Base;
using GoldBusinessManagementApp.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GoldBusinessManagementApp.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public override async Task<ICollection<Customer>> GetAll()
        {
            return await _context.Customers.Where(c => !c.IsDeleted).ToListAsync();
        }
    }
}

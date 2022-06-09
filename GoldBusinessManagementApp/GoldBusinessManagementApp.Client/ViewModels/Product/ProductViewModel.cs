using GoldBusinessManagementApp.Client.ViewModels.Customer;

namespace GoldBusinessManagementApp.Client.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public string Weight { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}

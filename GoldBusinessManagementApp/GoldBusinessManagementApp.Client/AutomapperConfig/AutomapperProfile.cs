using AutoMapper;
using GoldBusinessManagementApp.Client.ViewModels.Customer;
using GoldBusinessManagementApp.Client.ViewModels.Product;
using GoldBusinessManagementApp.Model.Models;

namespace GoldBusinessManagementApp.Client.AutomapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerUpdateViewModel>();
            CreateMap<CustomerUpdateViewModel, Customer>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductUpdateViewModel>();
            CreateMap<ProductUpdateViewModel, Product>();
        }
    }
}

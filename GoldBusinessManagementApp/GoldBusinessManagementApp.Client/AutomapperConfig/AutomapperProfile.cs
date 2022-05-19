using AutoMapper;
using GoldBusinessManagementApp.Client.ViewModels.Customer;
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
        }
    }
}

using eStoreAPI.Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.BL.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> GetCustomerById(int id);
        Task<int> AddCustomer(CustomerModel customerModel);
        Task<int> UpdateCustomer(CustomerModel customerModel);
        Task<int> DeleteCustomer(int id);


    }
}

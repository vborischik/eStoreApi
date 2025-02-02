using AutoMapper;
using eStore.DAL.Models;
using eStore.DAL.Repositories;
using eStoreAPI.Areas.Models;


namespace eStore.BL.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerModel>>(customers);
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return _mapper.Map<CustomerModel>(customer);
        }

        public async Task<int> AddCustomer(CustomerModel customerModel)
        {
            var customer = _mapper.Map<CustomerDTO>(customerModel);
            return await _customerRepository.AddCustomer(customer);
        }

        public async Task<int> UpdateCustomer(CustomerModel customerModel)
        {
            var customer = _mapper.Map<CustomerDTO>(customerModel);
            return await _customerRepository.UpdateCustomer(customer);
        }

        public async Task<int> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }


    }
}

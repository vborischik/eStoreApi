using eStore.DAL.eStore.DAL;
using eStore.DAL.Models;
using eStore.DAL.Repositories;
using Microsoft.Extensions.Configuration;

public class CustomerRepository : BaseDAL, ICustomerRepository
{
    // No need for a separate _dbConnection field as BaseDAL handles connection creation.

    public CustomerRepository(IConfiguration configuration, string connectionName)
        : base(configuration, connectionName)
    {
    }

    public async Task<int> AddCustomer(CustomerDTO customer)
    {
        var sql = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
        return await ExecuteAsync(sql, customer);
    }
       

    public async Task<int> DeleteCustomer(int id)
    {
        var sql = "DELETE FROM Customers WHERE Id = @Id";
        return await ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
    {
        var sql = "SELECT * FROM Customers";
        return await QueryAsync<CustomerDTO>(sql);
    }

    public async Task<CustomerDTO> GetCustomerById(int id)
    {
        var sql = "SELECT * FROM Customers WHERE Id = @Id";
        return await QuerySingleAsync<CustomerDTO>(sql, new { Id = id });
    }

    public async Task<int> UpdateCustomer(CustomerDTO customer)
    {
        var sql = "UPDATE Customers SET Name = @Name, Email = @Email WHERE Id = @Id";
        return await ExecuteAsync(sql, customer);
    }


}
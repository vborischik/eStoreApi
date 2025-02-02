
using eStore.DAL.Repositories;      // For ICustomerRepository and CustomerRepository
using AutoMapper;
using eStore.BL.Services;
using eStore.Common;


namespace eStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register the CustomerRepository with the DI container.
            // Pass IConfiguration and connection string name ("DefaultConnection") to the constructor.
            builder.Services.AddScoped<ICustomerRepository>(sp =>
                new CustomerRepository(sp.GetRequiredService<IConfiguration>(), "DefaultConnection"));

            // Register the CustomerService (Business Logic Layer)
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // Register AutoMapper with the MappingProfile from eStore.Common.Mappings.
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

using CSharpSqlDataBaseAssignment;
using CSharpSqlDataBaseAssignment.Contexts;
using CSharpSqlDataBaseAssignment.Repositories;
using CSharpSqlDataBaseAssignment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Solutions\CSharpSqlDataBaseAssignment\CSharpSqlDataBaseAssignment\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<RoleService>();
    services.AddScoped<ProductService>();
    services.AddScoped<CustomerService>();

    services.AddSingleton<ConsoleUI>();
}).Build();

var ConsoleUI = builder.Services.GetRequiredService<ConsoleUI>();
ConsoleUI.CreateProduct_UI();
ConsoleUI.GetProduct_UI();
ConsoleUI.UpdateProduct_UI();
ConsoleUI.DeleteProduct_UI();

ConsoleUI.CreateCustomer_UI();
ConsoleUI.GetCustomers_UI();
ConsoleUI.UpdateCustomer_UI();
ConsoleUI.DeleteCustomer_UI();
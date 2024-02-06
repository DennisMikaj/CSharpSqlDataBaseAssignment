using CSharpSqlDataBaseAssignment.Entities;
using CSharpSqlDataBaseAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressService _addressService;
        private readonly RoleService _roleService;

        public CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
            _roleService = roleService;
        }


        public CustomerEntity? CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
        {
            
            var roleEntity = _roleService.CreateRole(roleName);
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);
            try
            {
                var customerEntity = new CustomerEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    RoleId = roleEntity.Id,
                    AddressId = addressEntity.Id
                };
                customerEntity = _customerRepository.Create(customerEntity);
                return customerEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in CreateCustomer: {ex.Message}");
                return null;
            }
        }

        public CustomerEntity? GetCustomerEmail(string email)
        {
            try
            {
                var customerEntity = _customerRepository.Get(x => x.Email == email);
                return customerEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCustomerEmail: {ex.Message}");
                return null;
            }
        }

        public CustomerEntity GetCustomerById(int id)
        {
            try
            {
                var customerEntity = _customerRepository.Get(x => x.Id == id);
                return customerEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCustomerById: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<CustomerEntity>? GetCustomers()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCustomers: {ex.Message}");
                return null;
            }
        }

        public CustomerEntity? UpdateCustomer(CustomerEntity customerEntity)
        {
            try
            {
                var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
                return updatedCustomerEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in UpdateCustomer: {ex.Message}");
                return null;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in DeleteCustomer: {ex.Message}");
            }
        }
    }
}

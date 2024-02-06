using CSharpSqlDataBaseAssignment.Entities;
using CSharpSqlDataBaseAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Services
{
    internal class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressEntity? CreateAddress(string streetName, string postalCode, string city)
        {
            try
            {
                var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
                addressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
                return addressEntity;
            }
            catch ( Exception ex)
            {
                Console.WriteLine($"An error occured in CreateAddress: {ex.Message}");
                return null;
            }
        }

        public AddressEntity? GetAddress(string streetName, string postalCode, string city)
        {
            try
            {
                var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
                return addressEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetAddress: {ex.Message}");
                return null;
            }
        }

        public AddressEntity? GetAddressById(int id)
        {
            try
            {
                var addressEntity = _addressRepository.Get(x => x.Id == id);
                return addressEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetAddressById: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<AddressEntity>? GetAddresses()
        {
            try
            {
                var addresses = _addressRepository.GetAll();
                return addresses;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetAddresses: {ex.Message}");
                return null;
            }
        }

        public AddressEntity? UpdateAddress(AddressEntity addressEntity)
        {
            try
            {
                var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
                return updatedAddressEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in UpdateAddress: {ex.Message}");
                return null;
            }
        }

        public void DeleteAddress(int id)
        {
            try
            {
                _addressRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in DeteleAddress: {ex.Message}");
            }
        }


    }
}

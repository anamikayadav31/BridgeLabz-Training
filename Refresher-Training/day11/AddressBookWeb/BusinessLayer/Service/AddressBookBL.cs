using BusinessLayer.Interface;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        // Repository object
        private readonly IAddressBookRL _repository;

        // Constructor - gets repository using Dependency Injection
        public AddressBookBL(IAddressBookRL repository)
        {
            _repository = repository;
        }

        // Get all contacts
        public List<AddressBookEntity> GetAll()
        {
            return _repository.GetAll();
        }

        // Get one contact by ID
        public AddressBookEntity? GetById(int id)
        {
            return _repository.GetById(id);
        }

        // Add a new contact
        public AddressBookEntity Add(AddressBookDTO dto)
        {
            // Convert DTO into Entity
            var entity = new AddressBookEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            // Send entity to Repository
            return _repository.Add(entity);
        }

        // Update an existing contact
        public AddressBookEntity? Update(int id, AddressBookDTO dto)
        {
            // Convert DTO into Entity
            var entity = new AddressBookEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            // Send updated data to Repository
            return _repository.Update(id, entity);
        }

        // Delete a contact
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
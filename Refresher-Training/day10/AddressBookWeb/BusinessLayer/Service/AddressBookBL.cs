using BusinessLayer.Interface;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        // ------------------------------------------------
        // Repository object
        // ------------------------------------------------

        // We use this object to communicate with
        // the Repository Layer.
        private readonly IAddressBookRL _repository;


        // ------------------------------------------------
        // Constructor
        // ------------------------------------------------

        // Dependency Injection gives us the Repository object.
        public AddressBookBL(IAddressBookRL repository)
        {
            _repository = repository;
        }


        // ------------------------------------------------
        // GET ALL CONTACTS
        // ------------------------------------------------

        public List<AddressBookEntity> GetAll()
        {
            // Ask Repository Layer to get all contacts
            return _repository.GetAll();
        }


        // ------------------------------------------------
        // GET CONTACT BY ID
        // ------------------------------------------------

        public AddressBookEntity? GetById(int id)
        {
            // Ask Repository Layer to find contact by ID
            return _repository.GetById(id);
        }


        // ------------------------------------------------
        // ADD CONTACT
        // ------------------------------------------------

        public AddressBookEntity Add(AddressBookDTO dto)
        {
            // DTO contains data coming from the API.

            // Convert DTO into Entity.
            var entity = new AddressBookEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            // Send Entity to Repository Layer
            return _repository.Add(entity);
        }


        // ------------------------------------------------
        // UPDATE CONTACT
        // ------------------------------------------------

        public AddressBookEntity? Update(
            int id,
            AddressBookDTO dto)
        {
            // Convert DTO into Entity.
            var entity = new AddressBookEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            // Send updated Entity to Repository
            return _repository.Update(id, entity);
        }


        // ------------------------------------------------
        // DELETE CONTACT
        // ------------------------------------------------

        public bool Delete(int id)
        {
            // Ask Repository Layer to delete the contact
            return _repository.Delete(id);
        }
    }
}
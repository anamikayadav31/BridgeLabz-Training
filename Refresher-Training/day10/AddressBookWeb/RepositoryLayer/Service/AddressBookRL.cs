using ModelLayer.Entities;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service;

public class AddressBookRL : IAddressBookRL
{
    private readonly AddressBookDbContext _context;

    public AddressBookRL(AddressBookDbContext context)
    {
        _context = context;
    }

    public List<AddressBookEntity> GetAll()
    {
        return _context.AddressBooks.ToList();
    }

    public AddressBookEntity? GetById(int id)
    {
        return _context.AddressBooks.FirstOrDefault(a => a.Id == id);
    }

    public AddressBookEntity Add(AddressBookEntity entity)
    {
        _context.AddressBooks.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public AddressBookEntity? Update(int id, AddressBookEntity entity)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return null;
        }

        existing.Name = entity.Name;
        existing.Email = entity.Email;
        existing.PhoneNumber = entity.PhoneNumber;
        existing.Address = entity.Address;

        _context.SaveChanges();
        return existing;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            return false;
        }

        _context.AddressBooks.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}

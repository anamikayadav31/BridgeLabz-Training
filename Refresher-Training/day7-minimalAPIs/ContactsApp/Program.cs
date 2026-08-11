using ContactsApp.Database;
using ContactsApp.Models;
using ContactsApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<DbConnection>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Home
app.MapGet("/", () =>
{
    return "Contacts API is running!";
});

// Get all contacts
app.MapGet("/contacts", (IContactRepository repo) =>
{
    List<Contact> contacts = repo.GetAll();
    return Results.Ok(contacts);
});

// Get contact by ID
app.MapGet("/contacts/{id:int}", (int id, IContactRepository repo) =>
{
    Contact? contact = repo.GetById(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }

    return Results.Ok(contact);
});

// Add contact
app.MapPost("/contacts", (Contact contact, IContactRepository repo) =>
{
    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        return Results.BadRequest("Name is required");
    }

    repo.Add(contact);

    return Results.Created("/contacts", contact);
});

// Update contact
app.MapPut("/contacts/{id:int}", (int id, Contact contact, IContactRepository repo) =>
{
    Contact? existingContact = repo.GetById(id);

    if (existingContact == null)
    {
        return Results.NotFound("Contact not found");
    }

    contact.Id = id;
    repo.Update(contact);

    return Results.Ok("Contact updated successfully");
});

// Delete contact
app.MapDelete("/contacts/{id:int}", (int id, IContactRepository repo) =>
{
    Contact? existingContact = repo.GetById(id);

    if (existingContact == null)
    {
        return Results.NotFound("Contact not found");
    }

    repo.Delete(id);

    return Results.Ok("Contact deleted successfully");
});

app.Run();